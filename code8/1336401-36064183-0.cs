    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace CSVFixer
    {
        public class CSV
        {
            public void fixCSV(string filePath)
            {
                string content = File.ReadAllText(filePath, Encoding.UTF8);
                string reEx = "\\r\\n\\s+";
                content = Regex.Replace(content, reEx,     "");                       
                File.WriteAllText(filePath, content, Encoding.UTF8);            
            }
        }
    }
