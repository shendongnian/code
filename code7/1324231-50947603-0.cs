    using System.Reflection;
    using System.IO;
    
    var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    var myAssembly = Assembly.LoadFrom(Path.Combine(appDir, "MyAssebmly.dll"));
