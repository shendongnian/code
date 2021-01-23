     private void Highlightimage_Load(object sender, EventArgs e)
                
                        {
                          
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                int x = Convert.ToInt32(table.Rows[i][0]);
                                int y = Convert.ToInt32(table.Rows[i][1]);
                                int width = Convert.ToInt32(table.Rows[i][2]);
                                int height = Convert.ToInt32(table.Rows[i][3]);
                                SelectedRect.Size = new Size(width, height);
                                SelectedRect.X = x;
                                SelectedRect.Y = y;
                                listRec.Add(SelectedRect);
                              
                            }
                
                            }
