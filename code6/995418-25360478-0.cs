    const string sPath = "movieAdd.txt";
    if (listBox1.SelectedItems.Count >= 1)
    {
        using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath))
        {
            foreach (var item in listBox1.SelectedItems)
            {
                SaveFile.WriteLine(item);
            }
        }
    }
