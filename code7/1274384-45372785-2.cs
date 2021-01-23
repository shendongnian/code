    namespace ZetaProducer.SuperSlimScriptingEngineProfiler.Helper
    {
        using Microsoft.Win32;
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Reflection;
        using System.Security.AccessControl;
        using System.Security.Principal;
        using Zeta.VoyagerLibrary.Common.IO;
    
        public static class ProfilerComRegistration
        {
            public const string ClsidString = @"1C406FBA-59EF-4FB2-938C-C1DA182D5914";
            public static readonly Guid Clsid = new Guid(ClsidString);
    
            /*
            REGEDIT4
    
            [HKEY_CLASSES_ROOT\ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback]
            @="ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback"
    
            [HKEY_CLASSES_ROOT\ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback\CLSID]
            @="{1C406FBA-59EF-4FB2-938C-C1DA182D5914}"
    
            [HKEY_CLASSES_ROOT\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}]
            @="ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback"
    
            [HKEY_CLASSES_ROOT\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}\InprocServer32]
            @="mscoree.dll"
            "ThreadingModel"="Both"
            "Class"="ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback"
            "Assembly"="ZetaProducer.SuperSlimScriptingEngineProfiler, Version=15.0.0.0, Culture=neutral, PublicKeyToken=null"
            "RuntimeVersion"="v4.0.30319"
            "CodeBase"="file:///C:/P/Zeta Producer/13/Zeta Producer Main/Bin/Applications/ZetaProducer.SuperSlimScriptingEngineProfiler.dll"
    
            [HKEY_CLASSES_ROOT\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}\InprocServer32\15.0.0.0]
            "Class"="ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback"
            "Assembly"="ZetaProducer.SuperSlimScriptingEngineProfiler, Version=15.0.0.0, Culture=neutral, PublicKeyToken=null"
            "RuntimeVersion"="v4.0.30319"
            "CodeBase"="file:///C:/P/Zeta Producer/13/Zeta Producer Main/Bin/Applications/ZetaProducer.SuperSlimScriptingEngineProfiler.dll"
    
            [HKEY_CLASSES_ROOT\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}\ProgId]
            @="ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback"
    
            [HKEY_CLASSES_ROOT\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}\Implemented Categories\{62C8FE65-4EBB-45E7-B440-6E39B2CDBF29}]
            */
    
            /*
            Siehe http://www.hexacorn.com/blog/2014/04/27/beyond-good-ol-run-key-part-11/:
    
            [HKEY_CURRENT_USER\Environment]
            "JS_PROFILER"="{1C406FBA-59EF-4FB2-938C-C1DA182D5914}"
             */
    
            public static void Register()
            {
                // Achtung vor dem Wow6432Node-Schlüssel.
                // https://stackoverflow.com/questions/2039186/reading-the-registry-and-wow6432node-key
                var views = new[]
                {
                    RegistryView.Registry32,
                    RegistryView.Registry64
                };
    
                foreach (var registryView in views)
                {
                    var key = checkCreateKey(
                        registryView,
                        @"Software\Classes\ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback");
                    if (key != null)
                    {
                        key.SetValue(null,
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback",
                            RegistryValueKind.String);
                        key.Close();
                    }
    
                    key = checkCreateKey(
                        registryView,
                        @"Software\Classes\ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback\CLSID");
                    if (key != null)
                    {
                        key.SetValue(null, $@"{{{ClsidString}}}", RegistryValueKind.String);
                        key.Close();
                    }
    
                    key = checkCreateKey(
                        registryView,
                        $@"Software\Classes\CLSID\{{{ClsidString}}}");
                    if (key != null)
                    {
                        key.SetValue(null,
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback",
                            RegistryValueKind.String);
                        key.Close();
                    }
    
                    key = checkCreateKey(
                        registryView,
                        $@"Software\Classes\CLSID\{{{ClsidString}}}\InprocServer32");
                    if (key != null)
                    {
                        key.SetValue(null, @"mscoree.dll", RegistryValueKind.String);
                        key.SetValue(@"ThreadingModel", @"Both", RegistryValueKind.String);
                        key.SetValue(@"Class",
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback",
                            RegistryValueKind.String);
                        key.SetValue(@"Assembly",
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler, Version=15.0.0.0, Culture=neutral, PublicKeyToken=null",
                            RegistryValueKind.String);
                        key.SetValue(@"RuntimeVersion", @"v4.0.30319", RegistryValueKind.String);
                        key.SetValue(@"CodeBase", getFileUrl(), RegistryValueKind.String);
                        key.Close();
                    }
    
                    key = checkCreateKey(
                        registryView,
                        $@"Software\Classes\CLSID\{{{ClsidString}}}\InprocServer32\15.0.0.0");
                    if (key != null)
                    {
                        key.SetValue(@"Class",
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback",
                            RegistryValueKind.String);
                        key.SetValue(@"Assembly",
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler, Version=15.0.0.0, Culture=neutral, PublicKeyToken=null",
                            RegistryValueKind.String);
                        key.SetValue(@"RuntimeVersion", @"v4.0.30319", RegistryValueKind.String);
                        key.SetValue(@"CodeBase", getFileUrl(), RegistryValueKind.String);
                        key.Close();
                    }
    
                    key = checkCreateKey(
                        registryView,
                        $@"Software\Classes\CLSID\{{{ClsidString}}}\ProgId");
                    if (key != null)
                    {
                        key.SetValue(null,
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback",
                            RegistryValueKind.String);
                        key.Close();
                    }
    
                    // Aus der Dokumentation https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/scripting-articles/cc843609(v=vs.94):
                    //
                    // The JavaScript language runtime checks the JS_PROFILER environment variable on creation
                    // to determine whether profiling should be enabled. If this variable is set to the CLSID
                    // of the profiler, the language runtime creates an instance of the profiler COM object,
                    // using the value of the variable to determine which profiler to create.
    
                    // Ein Beispiel habe ich hier gefunden:
                    // http://www.hexacorn.com/blog/2014/04/27/beyond-good-ol-run-key-part-11/
    
                    key = checkCreateKey(registryView, @"Environment");
                    if (key != null)
                    {
                        key.SetValue(@"JS_PROFILER", $@"{{{ClsidString}}}", RegistryValueKind.String);
                        key.Close();
                    }
                }
            }
    
            private static string getFileUrl()
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                    @"ZetaProducer.SuperSlimScriptingEngineProfiler.dll");
                return PathHelper.ConvertFilePathToFileUrl(filePath);
            }
    
            public static void Unregister()
            {
                // Achtung vor dem Wow6432Node-Schlüssel.
                // https://stackoverflow.com/questions/2039186/reading-the-registry-and-wow6432node-key
                var views = new[]
                {
                    RegistryView.Registry32,
                    RegistryView.Registry64
                };
    
                foreach (var registryView in views)
                {
                    var baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView);
    
                    var key = baseKey.OpenSubKey(@"Software\Classes", true);
    
                    if (key != null &&
                        new List<string>(key.GetSubKeyNames()).Contains(
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback"))
                    {
                        try
                        {
                            key.DeleteSubKeyTree(
                                @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback", false);
                        }
                        catch (AccessViolationException)
                        {
                        }
    
                        key.Close();
                    }
    
                    key = baseKey.OpenSubKey(@"Software\Classes\CLSID", true);
    
                    if (key != null &&
                        new List<string>(key.GetSubKeyNames()).Contains($@"{{{ClsidString}}}"))
                    {
                        try
                        {
                            key.DeleteSubKeyTree($@"{{{ClsidString}}}", false);
                        }
                        catch (AccessViolationException)
                        {
                        }
    
                        key.Close();
                    }
    
                    key = baseKey.OpenSubKey(@"Environment", true);
                    if (key != null)
                    {
                        key.DeleteValue(@"JS_PROFILER", false);
                        key.Close();
                    }
                }
            }
    
            private static RegistryKey checkCreateKey(RegistryView registryView, string keyPath)
            {
                // Achtung vor dem Wow6432Node-Schlüssel.
                // https://stackoverflow.com/questions/2039186/reading-the-registry-and-wow6432node-key
    
                var rs = new RegistrySecurity();
    
                // Jeder.
                var user = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
    
                rs.AddAccessRule(
                    new RegistryAccessRule(
                        user,
                        RegistryRights.FullControl,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None,
                        AccessControlType.Allow));
    
                var key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView)
                    .CreateSubKey(
                        keyPath,
                        RegistryKeyPermissionCheck.ReadWriteSubTree,
                        rs);
    
                return key;
            }
        }
    }
