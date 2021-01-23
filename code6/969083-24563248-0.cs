    class Program
    {
        static void Main(string[] args)
        {
            var root = ProjectRootElement.Create();
            var group = root.AddPropertyGroup();
            group.AddProperty("Configuration", "Debug");
            group.AddProperty("Platform", "x64");
            // references
            AddItems(root, "Reference", "System", "System.Core");
            
            // items to compile
            AddItems(root, "Compile", "test.cs");
            var target = root.AddTarget("Build");
            var task = target.AddTask("Csc");
            task.SetParameter("Sources", "@(Compile)");
            task.SetParameter("OutputAssembly", "test.dll");
            root.Save("test.csproj");
            Console.WriteLine(File.ReadAllText("test.csproj"));
        }
        private static void AddItems(ProjectRootElement elem, string groupName, params string[] items)
        {
            var group = elem.AddItemGroup();
            foreach(var item in items)
            {
                group.AddItem(groupName, item);
            }
        }
    }
