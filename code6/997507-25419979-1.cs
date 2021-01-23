    using System.IO;    
    using System.Reflection;
    
    public static string ExecutionDirectoryPathName()
        {
             var dirPath = Assembly.GetExecutingAssembly().Location;
             dirPath = Path.GetDirectoryName(dirPath);
             return Path.GetFullPath(Path.Combine(dirPath, "\EmailTemplateHtml\MailTemplate.html"));
        }
