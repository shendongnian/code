    //css_reference DocX.dll;
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Novacode;
    
    class Script
    {
        [STAThread]
        static public void Main(string[] args)
        {
            using (DocX doc = DocX.Create(@"C:\Users\name\Desktop\test.docx"))
            {
                 doc.PageLayout.Orientation = Orientation.Landscape;
                 var table = doc.AddTable(12, 2); 
                 doc.InsertTable(table);
                 doc.Save();
            }
        }
    }
