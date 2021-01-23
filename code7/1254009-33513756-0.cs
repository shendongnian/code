    public class UserControl1 : Control
    {
        public UserControl1()
        {
            // ...
            ApplyChildEvents(this);
        }
    
        private void ApplyChildEvents(Control control)
        {
            foreach (Control subcontrol in control.Controls)
            {
                subcontrol.MouseMove += _UserControl_MouseMove;
                subcontrol.DragDrop += _UserControl_DragDrop;
                subcontrol.DragEnter += _UserControl_DragEnter;
                ApplyChildEvents(subcontrol);
            }
        }
    }
