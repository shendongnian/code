    class Program
    {
        static void Main(string[] args)
        {
            string nameOfSolutionForThisProject = @"MySolutionFile.sln";
            string wrapperContent = SolutionWrapperProject.Generate(nameOfSolutionForThisProject, toolsVersionOverride: null, projectBuildEventContext: null);
            byte[] rawWrapperContent = Encoding.Unicode.GetBytes(wrapperContent.ToCharArray());
            using (MemoryStream memStream = new MemoryStream(rawWrapperContent))
            using (XmlTextReader xmlReader = new XmlTextReader(memStream))
            {
                Project proj = ProjectCollection.GlobalProjectCollection.LoadProject(xmlReader);
                foreach (var p in proj.ConditionedProperties)
                {
                    Console.WriteLine(p.Key);
                    Console.WriteLine(string.Join(", ", p.Value));
                }
            }
            Console.ReadLine();
        }
    }
