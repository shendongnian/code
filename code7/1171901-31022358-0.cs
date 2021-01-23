    public partial class Form1 : Form
    {
      private int _MouseIndex = -1;
        
      public Form1()
      { InitializeComponent(); }
    
      private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
      {
        Brush textBrush = SystemBrushes.WindowText;
    
        if (e.Index > -1)
        {
          if (e.Index == _MouseIndex)
          {
            e.Graphics.FillRectangle(SystemBrushes.HotTrack, e.Bounds);
            textBrush = SystemBrushes.HighlightText;
          }
          else
          {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
              e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
              textBrush = SystemBrushes.HighlightText;
            }
            else
              e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
          }
          e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Left + 2, e.Bounds.Top);
        }
      }
    
      private void listBox1_MouseMove(object sender, MouseEventArgs e)
      {
        int index = listBox1.IndexFromPoint(e.Location);
        if (index != _MouseIndex)
        {
          _MouseIndex = index;
          listBox1.Invalidate();
        }
      }
    
      private void listBox1_MouseLeave(object sender, EventArgs e)
      {
        if (_MouseIndex > -1)
        {
          _MouseIndex = -1;
          listBox1.Invalidate();
        }
      }
    }
