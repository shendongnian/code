    private static void writeText()
        {
            using (TextWriter tw = new StreamWriter(@"C:myTestFile.txt"))
            {
                tw.WriteLine("Hello World",false);
                tw.Close();
            }
        }
