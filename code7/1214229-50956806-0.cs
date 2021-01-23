    public class RichTextBoxEx : RichTextBox
    {
        private const int WM_SETCURSOR = 0x20;
        protected override void WndProc(ref Message m) 
        {
            if (m.Msg == WM_SETCURSOR) 
            {
                if (SelectionType == RichTextBoxSelectionTypes.Object) 
                {
                    m.LParam = new IntPtr(0x2000012);
                }
            }
            base.WndProc(ref m);
        }
    }
