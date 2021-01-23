            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; 
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
    
                e.Graphics.Clear(Color.Black); //Clear the background with the black color
    
                if(m_bmp != null)  //if m_bmp == null, then do nothing.
                {
                    //To calculate the proper display area's width and height that fit the window.
                    if (this.Width / (double)this.Height > m_bmp.Width / (double)m_bmp.Height)
                    {
                        m_draw_height = (int)(this.Height * m_roomRatio);
                        m_draw_width = (int)(m_bmp.Width / (double)m_bmp.Height * m_draw_height);
                    }
                    else
                    {
                        m_draw_width = (int)(this.Width * m_roomRatio);
                        m_draw_height = (int)(m_bmp.Height / (double)m_bmp.Width * m_draw_width);
                    }
    
                    //To calculate the starting point.
                    m_draw_x = (int)((this.Width - m_draw_width) / 2.0 + m_offsetX / 2.0);
                    m_draw_y = (int)((this.Height - m_draw_height) / 2.0 + m_offsetY / 2.0);
                    e.Graphics.DrawImage(m_bmp, m_draw_x, m_draw_y, m_draw_width, m_draw_height);
    
                    //draw some useful information
                    string window_info = "m_draw_x" + m_draw_x.ToString() + "m_draw_width" + m_draw_width.ToString();
                    e.Graphics.DrawString(window_info, this.Font, new SolidBrush(Color.Yellow), 0, 20);
                }
