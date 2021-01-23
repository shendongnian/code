     foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                var Id = row.Cells["ID"].Value.ToString();
                int leadID;
                if (!String.IsNullOrWhiteSpace(Id) && int.TryParse(Id, out ID))
                {
                    Label label = new Label();
                
                    label.Text = row.Cells["Name"].Value.ToString();
     
                }
            }
