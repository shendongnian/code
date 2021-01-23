    foreach (ListViewItem row in ListView2.Items)
        {            
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if( cb != null)
                {
                    if (cb.Checked == true)
                    {
                           //Some Stuf..
                    }
                }
        }
