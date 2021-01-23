    protected override void OnDrawItem(DrawItemEventArgs e)
    {
       e.DrawBackground();
       if (e.Index >= 0 && DroppedDown) {  
       Brush brs = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
       new SolidBrush(SelectedBackColor) : new SolidBrush(Color.Red);
       e.Graphics.FillRectangle(brs, e.Bounds);
       using (StringFormat sformat = new StringFormat()) {
            sformat.LineAlignment = StringAlignment.Center;
            sformat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, sformat);
    } 
