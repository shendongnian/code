     public static void printThread(object fiObject)
            {
                
                FileInfo fi = (FileInfo)fiObject;
                try
                {
    
                    Microsoft.Office.Interop.Word.Application wordInstance = new Microsoft.Office.Interop.Word.Application();
                    //MemoryStream documentStream = getDocStream(); 
                    FileInfo wordFile = new FileInfo(fi.FullName);
                    object fileObject = wordFile.FullName;
                    object oMissing = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Word.Document doc = wordInstance.Documents.Open(ref fileObject, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    doc.Activate();
                    doc.PrintOut(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                    Console.WriteLine("Printed " + fi.FullName);
                }
    
                catch (Exception ex)
                {
                    Console.WriteLine("Error:  " + ex);
                }
    
    
            }
