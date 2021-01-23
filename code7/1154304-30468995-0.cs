    public class CustomDesigner : ControlDesigner
    {
        protected override void WndProc(ref Message m)
        {
            DefWndProc(ref m);//Passes message to the control.
        }
    }
