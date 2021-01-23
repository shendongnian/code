        /// <summary>
        /// This binder looks for not found <see cref="Type"/>s in the unloaded assemblies of the repositories.
        /// </summary>
        public class RepositoryTypesBinder : DefaultSerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type type = null;
                try
                {
                    type = base.BindToType(assemblyName, typeName);
                    if (type != null)
                    {
                        return type;
                    }
                }
                catch (JsonSerializationException)
                {
                    // Type has not been found, so try to find type in some repositories
                    foreach (var repository in DeviceInformationManager.InformationSources.OfType<DeviceDriverRepository.DeviceDriverRepository>())
                    {
                        // Search for assembly paths and check their names
                        foreach (var driverUri in repository.GetDriverUris(null))
                        {
                            var targetAssemblyName = AssemblyName.GetAssemblyName(driverUri.LocalPath);
                            if (targetAssemblyName != null && targetAssemblyName.FullName.Equals(assemblyName))
                            {
                                // Load assembly into AppDomain
                                Assembly assembly = Assembly.Load(targetAssemblyName);
                                type = assembly.GetType(typeName, false);
                                if (type != null)
                                {
                                    return type; // If type was found: finish
                                }
                                // else continue
                            }
                        }
                    }
                    // If not sufficient type has found until here: throw Error;
                    throw;
                }
                return null;
            }
            public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
            {
                assemblyName = serializedType.Assembly.FullName;
                typeName = serializedType.FullName;
            }
        }
