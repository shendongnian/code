    Inspector inspector = newMailItem.GetInspector;
    if (inspector.IsWordMail())
    {
        newMailItem.Display();
        wordDocument = inspector.WordEditor as Microsoft.Office.Interop.Word.Document;
        Microsoft.Office.Interop.Word.Range range = wordDocument.Range(wordDocument.Content.Start, wordDocument.Content.End);
        Microsoft.Office.Interop.Word.Find findObject = range.Find;
        findObject.ClearFormatting();
        findObject.Text = "old value";
        findObject.Replacement.ClearFormatting();
        findObject.Replacement.Text = "new value";
        object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
        findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);
    }
