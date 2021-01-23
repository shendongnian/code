    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
                        {
                            foreach (Rectangle rec in listRec)
                            {
                                SelectedRect = MakeRectangle(rec.Left, rec.Top, rec.Right, rec.Bottom);
                
                                if (
                      (e.X >= SelectedRect.Left) && (e.X <= SelectedRect.Right) &&
                      (e.Y >= SelectedRect.Top) && (e.Y <= SelectedRect.Bottom))
                                {
                
                                    MessageBox.Show("test");
                                }
                            }
                        }
