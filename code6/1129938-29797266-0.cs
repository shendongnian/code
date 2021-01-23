    if (MessageBox.Show("Doriti sa stergeti autogara?", "Stergere", MessageBoxButtons.YesNo) == DialogResult.Yes)
	{
	    //parameters cant be System.Int32[]
		var IdsToDelete = new List<string>();
		foreach (DataGridViewRow item in this.grdAutogari.SelectedRows)
		{
			grdAutogari.Rows.RemoveAt(item.Index);
            //you probably need to use item.ID or the column that holds your 
            //Primary key for your sql statement
			IdsToDelete.Add(item.Index.ToString());
		}
		//assuming you have a DataContext of some sort. 
		//Maybe Entity Framework or Linq-To-Sql
		db.ExecuteCommand("delete from [YOURTABLENAME] where YOURTABLENAME.Id in ({0})", IdsToDelete.ToArray());
	}
