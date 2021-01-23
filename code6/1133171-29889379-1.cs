            if(lstprodbacklog.Count>0)
            {
                cbx_pbnum.Items.Clear();
                foreach (ProductBacklog pb in lstprodbacklog)
                {
                    if (cbx_projectname.SelectedValue.ToString() == pb.ProjectTableId.ToString())
                    {
                        cbx_pbnum.Items.Add(pb.PBNum);                           
                    }
                }
            }
}
