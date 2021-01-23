    public class PictureBoxScaleable : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.ScaleTransform(.2f, .2f);
            base.OnPaint(pe);
        }
    }
