        protected void gvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iCustomerID = Convert.ToInt32(Library.gvGetVal(gvCustomer, "CustomerID"));
            Session[SSS.CustomerID] = iCustomerID;
        }
    public class Library
    {
        public static string gvGetVal(GridView gvGrid, string sHeaderText)
        {
            string sRetVal = string.Empty;
            if (gvGrid.Rows.Count > 0)
            {
                if (gvGrid.SelectedRow != null)
                {
                    GridViewRow row = gvGrid.SelectedRow;
                    int iCol = gvGetColumn(gvGrid, sHeaderText);
                    if (iCol > -1)
                        sRetVal = row.Cells[iCol].Text;
                }
            }
            return sRetVal;
        }
        private static int gvGetColumn(GridView gvGrid, string sHeaderText)
        {
            int iRetVal = -1;
            for (int i = 0; i < gvGrid.Columns.Count; i++)
            {
                if (gvGrid.Columns[i].HeaderText.ToLower().Trim() == sHeaderText.ToLower().Trim())
                {
                    iRetVal = i;
                }
            }
            return iRetVal;
        }
    }
