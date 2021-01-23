     Public sub main()
                Dim rtfLoc = "c:/temp.rtf"
                Dim dotXLoc = "c:/temp.dotx"
                Dim Fileformat As Microsoft.Office.Interop.Word.WdSaveFormat = Word.WdSaveFormat.wdFormatXMLTemplate
                Dim wordApp As Word.Application = New Microsoft.Office.Interop.Word.Application()
                Dim currentDoc As Microsoft.Office.Interop.Word.Document = wordApp.Documents.Open(rtfLoc)
                TextToMergeField(currentDoc)
                currentDoc.SaveAs(dotXLoc, Fileformat)
                currentDoc.Close()
                wordApp.Quit()
     End Sub
