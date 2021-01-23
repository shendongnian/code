    internal class Program
    {
        private static void Main(string[] args)
        {
            var project = new Project("PathToYourProject.csproj");
            Console.WriteLine(project.GetProperty("TargetFrameworkVersion", true, string.Empty));
            Console.WriteLine(project.GetProperty("Platform", true, string.Empty));
            Console.WriteLine(project.GetProperty("WarningLevel", true, string.Empty));
            Console.WriteLine(project.GetProperty("TreatWarningsAsErrors", true, "false"));
            Console.WriteLine(project.GetProperty("OutputPath", false, string.Empty));
            Console.WriteLine(project.GetProperty("SignAssembly", true, "false"));
            Console.WriteLine(project.GetProperty("AssemblyName", false, string.Empty));
            Console.ReadLine();
        }
    }
    public static class ProjectExtensions
    {
        public static string GetProperty(this Project project, string propertyName, bool afterEvaluation, string defaultValue)
        {
            var property = project.GetProperty(propertyName);
            if (property != null)
            {
                if (afterEvaluation)
                    return property.EvaluatedValue;
                return property.UnevaluatedValue;
            }
            return defaultValue;
        }
    }
