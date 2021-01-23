    private void pictureBox1_Paint(object sender, PaintEventArgs e)
                
                        { Graphics g = e.Graphics;
                                foreach (Rectangle rec in listRec)
                                {
                                    Pen p = new Pen(Color.Red);
                                    g.DrawRectangle(p, rec);
                                }
                }
                 private Rectangle MakeRectangle(int x0, int y0, int x1, int y1)
                        {
                            return new Rectangle(
                                Math.Min(x0, x1),
                                Math.Min(y0, y1),
                                Math.Abs(x0 - x1),
                                Math.Abs(y0 - y1));
                        }
