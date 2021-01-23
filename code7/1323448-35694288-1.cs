    dynamic wordInstance = new Microsoft.Office.Interop.Word.Application();
    FileInfo wordFile = new FileInfo("2.docx");
    object fileObject = wordFile.FullName;
    object oMissing = System.Reflection.Missing.Value;
    dynamic doc = wordInstance.Documents.Open(ref fileObject);
    doc.Activate();
    doc.PrintOut(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
