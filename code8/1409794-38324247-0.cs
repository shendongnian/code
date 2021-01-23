    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.Build.Construction;
    using Microsoft.Build.Execution;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Logging;
    using Microsoft.Build.Tasks.Deployment.ManifestUtilities;
    using Microsoft.Build.Utilities;
    public class BootstrapperExample {
        private string GenerateBootstrapper(string manifestFile, string applicationName, string applicationUrl, params string[] prerequisites) {
            // root element
            ProjectRootElement xml = ProjectRootElement.Create();
            xml.ToolsVersion = "4.0";
            xml.DefaultTargets = "BuildBootstrapper";
            // build properties
            var propertyGroup = xml.AddPropertyGroup();
            propertyGroup.AddProperty("TargetFrameworkVersion", "v4.5");
            propertyGroup.AddProperty("VisualStudioVersion", "11.0");
            // prerequisites (product codes of each required package, e.g. ".NETFramework,Version=v4.5")
            var itemGroup = xml.AddItemGroup();
            foreach (string productCode in prerequisites) {
                itemGroup.AddItem("BootstrapperFile", productCode);
            }
            // target
            var target = xml.AddTarget("BuildBootstrapper");
            var task = target.AddTask("GenerateBootstrapper");
            task.SetParameter("ApplicationFile", Path.GetFileName(manifestFile));
            task.SetParameter("ApplicationName", applicationName);
            task.SetParameter("ApplicationUrl", applicationUrl);
            task.SetParameter("BootstrapperItems", "@(BootstrapperFile)");
            task.SetParameter("OutputPath", Path.GetDirectoryName(manifestFile));
            task.SetParameter("Path", @"C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\Bootstrapper");     // replace with actual path
            var proj = new ProjectInstance(xml);
            var req = new BuildRequestData(proj, new string[] { "BuildBootstrapper" });
            var parameters = new BuildParameters();
            // optional logging of the build process
            var logger = new FileLogger();
            Uri codeBase = new Uri(Assembly.GetEntryAssembly().CodeBase);
            logger.Parameters = "logfile=" + Path.Combine(Path.GetDirectoryName(codeBase.LocalPath), "msbuild.log");
            parameters.Loggers = new ILogger[] { logger };
            // build the bootstrapper executable (setup.exe)
            var result = BuildManager.DefaultBuildManager.Build(parameters, req);
            if (result.OverallResult == BuildResultCode.Failure) {
                throw new InvalidOperationException("MSBuild task failed!", result.Exception);
            }
            // return path to the built setup.exe
            return Path.Combine(Path.GetDirectoryName(manifestFile), "setup.exe");
        }
    }
