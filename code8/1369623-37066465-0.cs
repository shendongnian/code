     private void dgvMobileOperators_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (dgvMobileOperators.SelectedRows[0].Index != e.RowIndex)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dgvMobileOperators.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() == "1"  /*&& Convert.ToInt32(e.Value.ToString()) == 1*/)
                    {
                        e.PaintBackground(e.ClipBounds, false);
                        dgvMobileOperators[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
                        PointF p = e.CellBounds.Location;
                        // p.X += imageList1.ImageSize.Width;
                        p.X += 24;
                        // string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"EasySMPP\App\Images\sms.ico");
                        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + "\\Images\\connect_established.png";
                        e.Graphics.DrawImage(Image.FromFile(path), e.CellBounds.X, e.CellBounds.Y, 79,23);
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p);
                        e.Handled = true;
                    }
                    else if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dgvMobileOperators.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() == "0"/*&& Convert.ToInt32(e.Value.ToString()) == 0*/)
                    {
                        e.PaintBackground(e.ClipBounds, false);
                        dgvMobileOperators[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
                        PointF p = e.CellBounds.Location;
                        // p.X += imageList1.ImageSize.Width;
                        p.X += 24;
                        // string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"EasySMPP\App\Images\sms.ico");
                        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + "\\Images\\connect_no.png";
                        e.Graphics.DrawImage(Image.FromFile(path), e.CellBounds.X, e.CellBounds.Y, 79, 23);
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p);
                        e.Handled = true;
                    }
                }
                else
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dgvMobileOperators.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() == "1"  /*&& Convert.ToInt32(e.Value.ToString()) == 1*/)
                    {
                        e.PaintBackground(e.ClipBounds, false);
                        dgvMobileOperators[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
                        PointF p = e.CellBounds.Location;
                        // p.X += imageList1.ImageSize.Width;
                        p.X += 24;
                        // string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"EasySMPP\App\Images\sms.ico");
                        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + "\\Images\\connect-ok.png";
                        e.Graphics.DrawImage(Image.FromFile(path), e.CellBounds.X, e.CellBounds.Y, 79, 23);
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p);
                        e.Handled = true;
                    }
                    else if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dgvMobileOperators.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() == "0"/*&& Convert.ToInt32(e.Value.ToString()) == 0*/)
                    {
                        e.PaintBackground(e.ClipBounds, false);
                        dgvMobileOperators[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
                        PointF p = e.CellBounds.Location;
                        // p.X += imageList1.ImageSize.Width;
                        p.X += 24;
                        // string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"EasySMPP\App\Images\sms.ico");
                        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + "\\Images\\connect-fail.png";
                        e.Graphics.DrawImage(Image.FromFile(path), e.CellBounds.X, e.CellBounds.Y, 79, 23);
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p);
                        e.Handled = true;
                    }
                }
               
               
                 
            }
  
