    public partial class PoorTextBox : TextBox
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int) WM.LBUTTONDOWN)
            {
                return;//Eat mouse down events 
            }
            base.WndProc(ref m);
        }
    }
