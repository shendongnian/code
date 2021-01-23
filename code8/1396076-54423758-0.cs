                double iTotal,iQty,iPrice;
            try
            {
                var itmColumn = dgvEntry[e.ColumnIndex, e.RowIndex];
                if(itmColumn.OwningColumn.Index>0)
                {
                    iTotal = 0; iQty = 0; iPrice = 0;
                    foreach(DataGridViewRow row in dgvEntry.Rows)
                    {
            iQty = Convert.ToDouble(row.Cells[dgvDOentry.Columns["itQty"].Index].Value);
          iPrice = Convert.ToDouble(row.Cells[dgvDOentry.Columns["itRate"].Index].Value);
         row.Cells[dgvEntry.Columns["itTotal"].Index].Value = iQty * iPrice;
                    }
                }
            }
