                foreach (DataGridViewRow row in dgvOrderList.Rows)
                {
                    if (row.Selected)
                    {
                        dgvOrderList.Rows.RemoveAt(row.Index);
                        //break; //use break if you only select one row! if selected more, then remove it!
                        pids[i] = Convert.ToInt32(row.Cells[1].Value);
                        i++;
                        int div = Convert.ToInt32(row.Cells[5].Value);
                        total = Convert.ToInt32(txtTotalAmount.Text);
                        total = total - div;
                        txtTotalAmount.Text = total.ToString();
                    }
                }
