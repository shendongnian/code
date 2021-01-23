    //#Load on Demand
        private const int ItemsPerRequest = 50;
    
        private static string GetStatusMessage(int offset, int total)
        {
            if (total <= 0)
                return "No matches";
    
            return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
        }
    protected void ddlAccountCode_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            string c = ddlCompany.SelectedValue.ToString();
    
            DataTable dt = GetAccCode(c);
            DataView dv = new DataView(dt);
            string txt = e.Text;
            dv.RowFilter = string.Format("AccountDescription LIKE '%{0}%'", txt);       
            int a = dv.Count;
            if (dv.Count > 0)
            {
                dt = dv.ToTable();
            }
    
            RadComboBox combo = (RadComboBox)sender;
    
            int itemOffset = e.NumberOfItems;
            int endOffset = Math.Min(itemOffset + ItemsPerRequest, dt.Rows.Count);
            e.EndOfItems = endOffset == dt.Rows.Count;
    
            for (int i = itemOffset; i < endOffset; i++)
            {
                combo.Items.Add(new RadComboBoxItem(dt.Rows[i]["AccountDescription"].ToString(), dt.Rows[i]["AccountDescription"].ToString()));
            }
    
            if (!string.IsNullOrEmpty(e.Text))
            {
                int num = dv.Count;
                endOffset = dv.Count;
            }
                    
            e.Message = GetStatusMessage(endOffset, dt.Rows.Count); 
        }
        //#End of 'Load on Demand'
