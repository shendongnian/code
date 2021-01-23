    var filteredTypes = yourAssembly.GetTypes().Where(type => 
                    {
                        var nameAttrib = type.GetCustomAttribute<NameAttribute>();
                        return nameAttrib != null && "Class1".Equals(nameAttrib.Name);
                    });
