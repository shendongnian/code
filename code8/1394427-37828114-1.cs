            /* bool notAvailable = true; Wrong position */
            foreach (DataGridViewRow row in grdView.Rows)
            {
                bool notAvailable = true; // Place it here so it gets reset on each iteration
                
                if (!string.IsNullOrEmpty(row.Cells[clm.Index].Value.ToString()))
                {
                    notAvailable = false;
                    break;
                }
            }
            if (notAvailable)
            {
                grdView.Columns[clm.Index].Visible = false;
            }
