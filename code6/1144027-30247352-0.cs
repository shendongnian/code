    private void labelUpdate()
    {
        int id;
        if (hwdg.SelectedRows.Count >= inc)
        {
            hwdg.FirstDisplayedScrollingRowIndex = inc;
            hwdg.Rows[inc].Selected = true;
            id = (int)hwdg.Rows[inc]["Id"];
           //inc++;
            label27.Text = "Record" + (inc + 1) + " of " + ds2.Tables["tblComp"].Rows.Count;
        }
        else if(hwdg.SelectedRows.Count <= inc)
        {
            hwdg.Rows[inc - 1].Selected = true;
            id = (int)hwdg.Rows[inc - 1]["Id"];
            label27.Text = "Record" + (inc + 1) + " of " + ds2.Tables["tblComp"].Rows.Count;
        }
        // Do whatever you want to do with the id
    }
