    class FileReader
    {
        public string reader(string sentence)
        {
            string f = sentence;
            string lines = "";
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines +=line+ Environment.NewLine;
                }
                
                return lines;
            }
        }
    }
