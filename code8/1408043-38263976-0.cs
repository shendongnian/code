        private bool isWithZeroQty()
        {
            int zeros = 0;
            foreach (DataGridViewRow row in enrollmedsDataGridView.Rows)
            {
                if ((row.Cells["Qty"].Value.ToString() == "0") || (row.Cells["Qty"].Value.ToString() == "0.00"))
                {
                    zeros = 1;
                }
            }
            if (zeros > 0)
            { return true; }
            else
            { return false; }
        }
