            private static string GetFileMD5(string fileName) {
                using (var md5 = MD5.Create()) {
                    using (var fileStream = File.OpenRead(fileName)) {
                        return BitConverter.ToString(md5.ComputeHash(fileStream)).Replace("-", "").ToLower();
                    }
                }
            }
            private static bool DoesFileExist(string workingDir,string fileName) {
                var fileToCheck = GetFileMD5(fileName);
                var files = Directory.EnumerateFiles(workingDir);
                return files.Any(file => string.Compare(GetFileMD5(file), fileToCheck, StringComparison.OrdinalIgnoreCase) == 0);
            }
