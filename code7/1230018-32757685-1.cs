    using System;
    using System.Collections.Generic;
    using System.Text;
    using Spire.Doc;
    using System.Windows.Forms;
    using System.Drawing.Printing;
    
    
    namespace Doc_Print
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Document doc = new Document(); 
                doc.LoadFromFile("sample.doc");
                PrintDialog dialog = new PrintDialog();
                dialog.AllowPrintToFile = true; 
                dialog.AllowCurrentPage = true;
                dialog.AllowSomePages = true;
                dialog.UseEXDialog = true; 
                doc.PrintDialog = dialog;               
                PrintDocument printDoc = doc.PrintDocument; 
                printDoc.Print();
                if (dialog.ShowDialog() == DialogResult.OK)
                {               
                    printDoc.Print();
                }            
    
            }
        }
    }
