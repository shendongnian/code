     private void filterDatas()
    {
        dynamic query = from row in ListObjets where row.id.ToString.Contains(txtBoxId.Text) select row;
        if (query.Count > 0)
        {
            if (ListObjets.Count == query.Count)
            {
                datasBindingSource.DataSource = ListObjets;
            }
            else {
                datasBindingSource.DataSource = query;
            }
        }
        else {
            MessageBox.Show("No data found!");
            if (txtBoxId.Focused == true)
            {
                txtBoxId.ResetText();
            }
        }
    } 
