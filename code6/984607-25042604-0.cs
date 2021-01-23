    //A1 will be IEnumerable<String>
    var A1 = Directory.GetFileSystemEntries(textbox2_f2.Text, "*", SearchOption.AllDirectories)
        .Select(System.IO.Path.GetFileName);
    foreach (var a in A1)
    {
        listbox_2f.Items.Add(a);
    }
