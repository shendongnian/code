    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document docOpen = app.Documents.Open(flname);
    string read = docOpen.Text
    if(read.Contains(txtWordInput.Text)) {
         count1++;
         lbSearchList.Visible = true;
         lbSearchList.Items.Add(flname);
    }
    app.Documents.Close();
