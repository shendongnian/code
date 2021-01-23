    void makeDraggable(List<Control> draggables)
    {
        foreach (Control ctl in draggables)
        {
            ctl.MouseDown += (s, e) => 
                {
                    mDown = e.Location;
                    timer1.Start();
                    dragFrame.Size = ctl.Size;
                    if (dragFrame.BackgroundImage != null)
                        dragFrame.BackgroundImage.Dispose();
                    Bitmap bmp = new Bitmap(dragFrame.ClientSize.Width,
                                            dragFrame.ClientSize.Height);
                    ctl.DrawToBitmap(bmp, dragFrame.ClientRectangle);
                    dragFrame.BackgroundImage = bmp;
                    dragFrame.BringToFront();
                    dragFrame.Show();
                    ctl.DoDragDrop(ctl.Text, DragDropEffects.Copy | DragDropEffects.Move);
                };
            ctl.MouseUp += (s, e) =>
                {
                    dragFrame.Hide();
                    timer1.Stop();
                };
            ctl.Leave += (s, e) =>
            {
                dragFrame.Hide();
                timer1.Stop();
            };
        }
    }
