     AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(path);
                foreach (var item in assembly.Modules)
                {
                    foreach (var type in item.Types)
                    {
                        foreach (var method in type.Methods)
                        {
                            if (method.IsStatic && method.IsSpecialName && method.IsPublic && method.Name.Contains("op_Equality"))
                            {
                                //that type overides == operator
                            }
                        }
                    }
                }
