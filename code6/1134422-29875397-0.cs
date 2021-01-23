        static void WriteCsvFile()
        {
            FileInfo file = new FileInfo(@"<Path of the file>");
            StreamWriter writer = new StreamWriter(@"D:\output.csv", false);
            writer.WriteLine("{0},{1},{2}", "FNumber", "Name", "Size");
            writer.WriteLine("{0},{1},{2:D}", "1", "Save.bng", file.Length);
            writer.Close();
        }
