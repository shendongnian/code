    Index: src/Topshelf/Runtime/HostSettings.cs
    ===================================================================
    --- src/Topshelf/Runtime/HostSettings.cs	(original)
    +++ src/Topshelf/Runtime/HostSettings.cs	(add SetArguments)
    @@ -38,6 +38,11 @@
             string InstanceName { get; }
 
             /// <summary>
    +        ///   The additional arguments that should be appended when the service is installed
    +        /// </summary>
    +        string Arguments { get; }
    +
    +        /// <summary>
             ///   Returns the Windows service name, including the instance name, which is registered with the SCM Example: myservice$bob
             /// </summary>
             /// <returns> </returns>
    Index: src/Topshelf/Runtime/Windows/HostServiceInstaller.cs
    ===================================================================
    --- src/Topshelf/Runtime/Windows/HostServiceInstaller.cs	(original)
    +++ src/Topshelf/Runtime/Windows/HostServiceInstaller.cs	(add SetArguments)
    @@ -114,6 +114,9 @@
                 if (!string.IsNullOrEmpty(settings.Name))
                     arguments += string.Format(" -servicename \"{0}\"", settings.Name);
 
    +            if (!string.IsNullOrEmpty(settings.Arguments))
    +                arguments += " " + settings.Arguments;
    +
                 return new HostInstaller(settings, arguments, installers);
             }
 
    Index: src/Topshelf/Runtime/Windows/WindowsHostSettings.cs
    ===================================================================
    --- src/Topshelf/Runtime/Windows/WindowsHostSettings.cs	(original)
    +++ src/Topshelf/Runtime/Windows/WindowsHostSettings.cs	(add SetArguments)
    @@ -1,14 +1,14 @@
     // Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
    -//  
    -// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
    -// this file except in compliance with the License. You may obtain a copy of the 
    -// License at 
    -// 
    -//     http://www.apache.org/licenses/LICENSE-2.0 
    -// 
    -// Unless required by applicable law or agreed to in writing, software distributed 
    -// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
    -// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
    +//
    +// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
    +// this file except in compliance with the License. You may obtain a copy of the
    +// License at
    +//
    +//     http://www.apache.org/licenses/LICENSE-2.0
    +//
    +// Unless required by applicable law or agreed to in writing, software distributed
    +// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
    +// CONDITIONS OF ANY KIND, either express or implied. See the License for the
     // specific language governing permissions and limitations under the License.
     namespace Topshelf.Runtime.Windows
     {
    @@ -19,8 +19,8 @@
             HostSettings
         {
             public const string InstanceSeparator = "$";
    -        string _description;
    -        string _displayName;
    +        private string _description;
    +        private string _displayName;
 
             /// <summary>
             ///   Creates a new WindowsServiceDescription using empty strings for the properties. The class is required to have names by the consumers.
    @@ -49,6 +49,8 @@
                 _description = "";
             }
 
    +        public string Arguments { get; set; }
    +
             public string Name { get; set; }
 
             public string DisplayName
    @@ -68,7 +70,6 @@
                 set { _displayName = value; }
             }
 
    -
             public string Description
             {
                 get
    @@ -80,7 +81,6 @@
                 set { _description = value; }
             }
 
    -
             public string InstanceName { get; set; }
 
             public string ServiceName
    Index: src/Topshelf/Topshelf.csproj
    ===================================================================
    --- src/Topshelf/Topshelf.csproj	(original)
    +++ src/Topshelf/Topshelf.csproj	(add SetArguments)
    @@ -112,6 +112,7 @@
         <Compile Include="Configuration\HostConfigurators\SudoConfigurator.cs" />
         <Compile Include="Configuration\HostConfigurators\UninstallHostConfiguratorAction.cs" />
         <Compile Include="Configuration\HostConfigurators\UnknownCommandLineOptionHostConfigurator.cs" />
    +    <Compile Include="Configuration\Options\ArgumentsOption.cs" />
         <Compile Include="Configuration\Options\AutostartOption.cs" />
         <Compile Include="Configuration\Options\DelayedOption.cs" />
         <Compile Include="Configuration\Options\DisabledOption.cs" />
    @@ -221,6 +222,9 @@
       <ItemGroup>
         <Folder Include="Properties\" />
       </ItemGroup>
    +  <ItemGroup>
    +    <None Include="Internals\README.md" />
    +  </ItemGroup>
       <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
       <!-- To modify your build process, add your task inside one of the targets below and uncomment it.
            Other similar extension points exist, see Microsoft.Common.targets.
    Index: src/Topshelf/Hosts/InstallHost.cs
    ===================================================================
    --- src/Topshelf/Hosts/InstallHost.cs	(original)
    +++ src/Topshelf/Hosts/InstallHost.cs	(add SetArguments)
    @@ -139,6 +139,11 @@
                     _dependencies = dependencies;
                 }
 
    +            public string Arguments
    +            {
    +                get { return _settings.Arguments; }
    +            }
    +
                 public string Name
                 {
                     get { return _settings.Name; }
    Index: src/Topshelf/Configuration/HostConfigurators/CommandLineParserOptions.cs
    ===================================================================
    --- src/Topshelf/Configuration/HostConfigurators/CommandLineParserOptions.cs	(original)
    +++ src/Topshelf/Configuration/HostConfigurators/CommandLineParserOptions.cs	(add SetArguments)
    @@ -61,7 +61,9 @@
                     .Or(from disp in x.Definition("displayname")
                         select (Option)new DisplayNameOption(disp.Value))
                     .Or(from instance in x.Definition("instance")
    -                    select (Option)new InstanceOption(instance.Value)));
    +                    select (Option)new InstanceOption(instance.Value))
    +                .Or(from instance in x.Definition("arguments")
    +                    select (Option)new ArgumentsOption(instance.Value)));
             }
 
             internal static void AddUnknownOptions(ICommandLineElementParser<Option> x)
    Index: src/Topshelf/Configuration/HostConfigurators/HostConfiguratorImpl.cs
    ===================================================================
    --- src/Topshelf/Configuration/HostConfigurators/HostConfiguratorImpl.cs	(original)
    +++ src/Topshelf/Configuration/HostConfigurators/HostConfiguratorImpl.cs	(add SetArguments)
    @@ -64,7 +64,7 @@
                     yield return this.Failure("Name", "must be specified and not empty");
                 else
                 {
    -                var disallowed = new[] {' ', '\t', '\r', '\n', '\\', '/'};
    +                var disallowed = new[] { ' ', '\t', '\r', '\n', '\\', '/' };
                     if (_settings.Name.IndexOfAny(disallowed) >= 0)
                         yield return this.Failure("Name", "must not contain whitespace, '/', or '\\' characters");
                 }
    @@ -86,6 +86,11 @@
                 yield return this.Success("ServiceName", _settings.ServiceName);
             }
 
    +        public void SetArguments(string arguments)
    +        {
    +            _settings.Arguments = arguments;
    +        }
    +
             public void SetDisplayName(string name)
             {
                 _settings.DisplayName = name;
    Index: src/Topshelf/Configuration/HostConfigurators/HostConfigurator.cs
    ===================================================================
    --- src/Topshelf/Configuration/HostConfigurators/HostConfigurator.cs	(original)
    +++ src/Topshelf/Configuration/HostConfigurators/HostConfigurator.cs	(add SetArguments)
    @@ -17,6 +17,12 @@
         public interface HostConfigurator
         {
             /// <summary>
    +        ///   Specifies additional command line arguments that should be added when the service is registered
    +        /// </summary>
    +        /// <param name="name"> </param>
    +        void SetArguments(string arguments);
    +
    +        /// <summary>
             ///   Specifies the name of the service as it should be displayed in the service control manager
             /// </summary>
             /// <param name="name"> </param>
    Index: src/Topshelf/Configuration/Options/ArgumentsOption.cs
    ===================================================================
    --- src/Topshelf/Configuration/Options/ArgumentsOption.cs	(nonexistent)
    +++ src/Topshelf/Configuration/Options/ArgumentsOption.cs	(add SetArguments)
    @@ -0,0 +1,31 @@
    +ï»¿// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
    +//  
    +// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
    +// this file except in compliance with the License. You may obtain a copy of the 
    +// License at 
    +// 
    +//     http://www.apache.org/licenses/LICENSE-2.0 
    +// 
    +// Unless required by applicable law or agreed to in writing, software distributed 
    +// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
    +// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
    +// specific language governing permissions and limitations under the License.
    +namespace Topshelf.Options
    +{
    +    using HostConfigurators;
    +
    +    public class ArgumentsOption : Option
    +    {
    +        string _arguments;
    +
    +        public ArgumentsOption(string arguments)
    +        {
    +            _arguments = arguments;
    +        }
    +
    +        public void ApplyTo(HostConfigurator configurator)
    +        {
    +            configurator.SetArguments(_arguments);
    +        }
    +    }
    +}
    \ No newline at end of file
    Index: src/Topshelf/HelpText.txt
    ===================================================================
    --- src/Topshelf/HelpText.txt	(original)
    +++ src/Topshelf/HelpText.txt	(add SetArguments)
    @@ -28,8 +28,10 @@
                             installing
           -description      The service description the service should use when
                             installing
    -      -displayname      The display name the the service should use when
    +      -displayname      The display name the service should use when
                             installing
    +      -arguments        The command line arguments the service should
    +                        also get when installing
 
         start               Starts the service if it is not already running
       
    @@ -57,3 +59,10 @@
             Installs the service, appending the instance name to the service name
             so that the service can be installed multiple times. You may need to
             tweak the log4net.config to make this play nicely with the log files.
    +
    +    service install -arguments "-configFile \"C:\my folder\service.config\""
    +        Installs the service, appending the command line argument to the
    +        service so that the service will always retrieve this information
    +        when started.
    +        If double quotes are needed within the arguments they must be
    +        escaped by a backslash \" (see example).
