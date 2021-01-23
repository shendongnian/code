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
            //System.Windows.Forms.MessageBox.Show("filepathstr: " + filePathstr);
            string folderPathstr = Path.GetDirectoryName(filePathstr);
            //System.Windows.Forms.MessageBox.Show("folderPathstr: " + folderPathstr);
            try
            {
                Application ap = new Application();
                Document document = ap.Documents.Open(filePathstr);
                document.Fields.Update();
                foreach (Section section in document.Sections)
                {
                    document.Fields.Update();  // update each section
                    HeadersFooters headers = section.Headers;  //Get all headers
                    foreach (HeaderFooter header in headers)
                    {
                        Fields fields = header.Range.Fields;
                        foreach (Field field in fields)
                        {
                            field.Update();  // update all fields in headers
                        }
                    }
                    HeadersFooters footers = section.Footers;  //Get all footers
                    foreach (HeaderFooter footer in footers)
                    {
                        Fields fields = footer.Range.Fields;
                        foreach (Field field in fields)
                        {
                            field.Update();  //update all fields in footers
                        }
                    }
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
