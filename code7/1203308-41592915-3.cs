    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Office.Interop.Word;
    class Program
    {
        static void Main(string[] args)
        {
            List<string> path = new List<string>(args);
            string filePathstr = string.Join(" ", path.ToArray());
            string folderPathstr = Path.GetDirectoryName(filePathstr);
            try
            {
                Application ap = new Application();
                Document document = ap.Documents.Open(filePathstr);
                foreach (Field field in document.GetAllFields())
                {
                    field.Update();
                    
                    // Other stuff with field can be done here as well
                }    
                document.Save();
                document.Close();
            }
            catch (NullReferenceException)
            {
                System.Windows.Forms.MessageBox.Show("A valid file was not selected.");
            }
        }
    }
