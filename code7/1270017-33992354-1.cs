    private void IsItCaps(string myWord, Microsoft.Office.Interop.Word.Document myDoc)
    {
        var find = myDoc.Application.ActiveDocument.Range().Find;
        find.ClearFormatting();
        if (find.Font.AllCaps != 0)
        {
            MessageBox.Show(myWord + " is AllCaps.");
        }
        else if(find.Font.AllCaps == 0)
        {
            MessageBox.Show(myWord + " is not AllCaps.");
        }
    }
