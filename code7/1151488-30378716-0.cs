    var results;
    
    foreach (var i in CheckBoxList.Items)
    {
        if (i.Checked == true)
        { // Add selected ID to ListBox
            results += (from c in PTable.All()
                        where c.ID == i.Value // i.Value would be however you're storing the ID in the CheckBoxList
                        select c).ToList();
        }
    }
    ListBox.DataSource = results;
    ListBox.DataBind();
