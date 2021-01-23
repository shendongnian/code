    public class MyBoolEditor : UITypeEditor
    {
        public override bool GetPaintValueSupported
            (System.ComponentModel.ITypeDescriptorContext context)
        { return true; }
        public override void PaintValue(PaintValueEventArgs e)
        {
            var rect = e.Bounds;
            rect.Inflate(1, 1);
            ControlPaint.DrawCheckBox(e.Graphics, rect, ButtonState.Flat |
                (((bool)e.Value) ? ButtonState.Checked : ButtonState.Normal));
        }
    }
