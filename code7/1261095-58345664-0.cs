        public void Main()
        {
            string filename = @"C:\Temp\Gerard.txt";
            string fileinfo = "";
            string curline = "";
            TextReader tr = new StreamReader(filename);
            while ((curline = tr.ReadLine()) != null)
            {
                if (fileinfo != "")
                {
                    fileinfo = fileinfo + Environment.NewLine;
                }
                fileinfo = fileinfo + curline;
            }
            tr.Close();
            TextWriter tw = new StreamWriter(filename, false);
            tw.Write(fileinfo);
            tw.Close();
            Dts.TaskResult = (int)ScriptResults.Success;
        }
