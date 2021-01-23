    string classNameWithNameSpace = "Application.Data.Employee";
                Type target;
                var assemblyList = AppDomain.CurrentDomain.GetAssemblies();
                //line # XYZ
                var filteredAssembliesOfMyProduct =
                    assemblyList.Where(x => x.FullName.StartsWith("MyCompanyName.MyProductName"));
    
                foreach (Assembly assembly in filteredAssembliesOfMyProduct)
                    if (assembly.GetTypes().Any(x => x.FullName == classNameWithNameSpace))
                    {
                        target = assembly.GetTypes().First(x => x.FullName == classNameWithNameSpace);
                        break;
                    }
