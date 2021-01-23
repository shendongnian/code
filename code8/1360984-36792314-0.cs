    using (Novacode.DocX document = DocX.Load(template))
    {
	int i = 0;
	
    foreach (Novacode.Bookmark bookmark in document.Bookmarks)
    {
        var bookmarks = document.Bookmarks[i].Name;
        document.Bookmarks[bookmark.Name].SetText(dataGridViewRow.Cells[i+1].Value.ToString());
		i++;
    }                   
    document.SaveAs(path2);
    }
