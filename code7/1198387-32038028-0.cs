       public static void final()
        {
            string isPacPath = @"C:\sandbox\so_31812951\so_31812951\bin\Development\so_31812951.ispac";
            string packageName = "Package.dtsx";
            Application app = new Application();
            Package pkg = null;
            // https://msdn.microsoft.com/en-us/library/ff930196(v=sql.110).aspx
            Project proj = null;
            PackageItem pi = null;
            DTSExecResult results;
            ///////////////////////////////////////////////////////////////////
            // Run an SSIS package that has a Project parameter
            ///////////////////////////////////////////////////////////////////
            proj = Project.OpenProject(isPacPath);
            // Yes, I can see the packages in there
            foreach (var item in proj.PackageItems)
            {
                Console.WriteLine(string.Format("Project {0} contains package {1}", proj.Name, item.StreamName));
            }
            //Also able to see the project level parameters
            foreach (Parameter item in proj.Parameters)
            {
                Console.WriteLine(string.Format("Project {0} contains parameter {1} type of {2} current value {3}", proj.Name, item.Name, item.DataType, item.Value));
            }
            // assign a value to my project level parameter
            proj.Parameters["ProjectParameter"].Value = 10;
            // Get the package from the project collection
            pi = proj.PackageItems[packageName];
            // Convert the package into a package object
            pkg = pi.Package;
            // This is how we specify a package parameter value
            pkg.Parameters["PackageParam"].Value = 777;
            results = pkg.Execute();
            Console.WriteLine(results);
        }
