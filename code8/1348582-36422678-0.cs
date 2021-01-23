                 DataGridViewCell cell = grvItems.Rows[e.RowIndex].Cells["PRICE"];
                if (isCheked)
                {
                    cell.Tag = cell.Value;
                    cell.Value = "0.00";
                    lblReturnAmountVal.Text = "0.00";
                }
                else
                { 
                    //            use your cell's datatype here!!  VVV
                    if (cell.Tag != null) cell.Value = cell.Tag as decimal;
                }
