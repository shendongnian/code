    public static class Extensiones
    {
        public static string FolderName(this OpenFileDialog ofd)
        {
                string resp = "";
                resp = ofd.FileName.Substring(0, 3);
                var final = ofd.FileName.Substring(3);
                var info = final.Split('\\');
                for (int i = 0; i < info.Length - 1; i++)
                {
                    resp += info[i] + "\\";
                }
                return resp;
        }
    }
