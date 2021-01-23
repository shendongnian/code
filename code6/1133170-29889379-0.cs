            if(lstprodbacklog.Count>0)
            {
                foreach (ProductBacklog pb in lstprodbacklog)
                {
                    if (cbx_projectname.SelectedValue.ToString() == pb.ProjectTableId.ToString())
                    {
                        cbx_pbnum.ItemsSource = pb.PBNum;
                    }
                }
            }
        
        }
