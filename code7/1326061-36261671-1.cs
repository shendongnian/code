    public static class GrpcInitializer
    {
        public static void EnsureGrpcCSharpExtNativeDll()
        {
            var grpcCoreAssembly = Assembly.GetAssembly(typeof(Grpc.Core.Channel));
            var srcFolderPath = Path.GetDirectoryName(new Uri(grpcCoreAssembly.CodeBase).LocalPath);
            CopyGrpcCSharpExtNativeDll(srcFolderPath);
        }
        public static void CopyGrpcCSharpExtNativeDll(string srcFolderPath)
        {
            var grpcCoreAssembly = Assembly.GetAssembly(typeof(Grpc.Core.Channel));
            var grpcDllLocation = Path.GetDirectoryName(grpcCoreAssembly.Location);
            if (grpcDllLocation == null)
                return;
            var targetFolderPath = Path.Combine(grpcDllLocation, "nativelibs");
            if (Directory.Exists(targetFolderPath))
                return;
            srcFolderPath = Path.Combine(srcFolderPath, "nativelibs");
            DirectoryCopy(srcFolderPath, targetFolderPath, true);
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            if (string.IsNullOrEmpty(sourceDirName) || string.IsNullOrEmpty(destDirName))
            {
                throw new ArgumentNullException(
                    $"Directory paths cannot be empty. sourceDirName: {sourceDirName} | destDirName: {destDirName}");
            }
            var dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " +
                                                     sourceDirName);
            }
            var dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }
            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    var temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, true);
                }
            }
        }
    }
