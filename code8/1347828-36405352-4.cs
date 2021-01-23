    String catExportTXT = "txt";
    List<catData> mainCatSet = new List<catData>();
        
    using (var selectForm = new Class2(catExportTXT, mainCatSet.Cast<ISelectable>()))
    {
        var result = selectForm.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            var localvar = (catData)selectForm.SelectedItem;
        }
        else
        {
            Environment.Exit(0);
        }
    }
