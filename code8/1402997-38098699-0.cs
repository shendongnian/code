    private void flowLayoutPanel_6_Cards_DragDrop(object sender, DragEventArgs e)
    {
        PictureBox picture = (PictureBox)e.Data.GetData(typeof(PictureBox));    
        FlowLayoutPanel _source = (FlowLayoutPanel)picture.Parent;
        FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
        if (_source != _destination)
        {
            //where did you even get this from?
        }
        else
        {
            Point p = _destination.PointToClient(new Point(e.X, e.Y));
            var item = _destination.GetChildAtPoint(p);
            int index = _destination.Controls.GetChildIndex(item, false);
            _destination.Controls.SetChildIndex(picture, index);
            _destination.Invalidate();
        }
    }
    private void flowLayoutPanel_6_Cards_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.All;
    }
 
    void p_MouseDown(object sender, MouseEventArgs e)
    {
        PictureBox p = (PictureBox)sender;
        p.DoDragDrop(p, DragDropEffects.All);
    }
