        private static void PackageManager_PackageInstalled(object sender, PackageOperationEventArgs e)
        {
            var files = e.FileSystem.GetFiles(e.InstallPath, "*.dll", true);
            foreach (var file in files)
            {
                try
                {
                    AppDomain domain = AppDomain.CreateDomain("tmp");
                    Type typeProxyType = typeof(TypeProxy);
                    var typeProxyInstance = (TypeProxy)domain.CreateInstanceAndUnwrap(
                        typeProxyType.Assembly.FullName,
                        typeProxyType.FullName);
                    var type = typeProxyInstance.LoadFromAssembly(file, "<KnownTypeName>");
                    object instance = domain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("failed to load {0}", file);
                    Console.WriteLine(ex.ToString());
                }
            }
        }
