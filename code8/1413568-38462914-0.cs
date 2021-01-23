    public class FileAccessHelper
        {
            public static string GetLocalFilePath(string filename)
            {
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string o= Path.Combine(path, filename);
                return o;
            }
            public static void CopyAssetFile(string path, string fileName)
            {
                using (var br = new BinaryReader(Application.Context.Assets.Open(fileName)))
                {
                    using (var bw = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }
