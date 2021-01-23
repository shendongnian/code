    <#@ template language="C#" #>
    using System.Reflection;
    using System.Resources;
    using System.Runtime.InteropServices;
    #if DEBUG
    [assembly: AssemblyConfiguration("Debug")]
    #else
    [assembly: AssemblyConfiguration("Release")]
    #endif
    [assembly: AssemblyCompany("My Company")]
    [assembly: AssemblyProduct("My Product")]
    [assembly: AssemblyCopyright("Copyright © My Company <#=DateTime.Now.Year#>")]
    [assembly: AssemblyTrademark("")]
    [assembly: AssemblyCulture("")]
    [assembly: NeutralResourcesLanguage("en")]
    [assembly: ComVisible(false)]
    [assembly: AssemblyFileVersion("1.0.0.0")]
    // etc.
