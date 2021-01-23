        public static void fileAttributes(string path)
        {
            try
            {
                FileAttributes att = File.GetAttributes(path);
                att = RemoveAtt(att, FileAttributes.Hidden | FileAttributes.ReadOnly);
                File.SetAttributes(path, att);
                Console.WriteLine(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
 
