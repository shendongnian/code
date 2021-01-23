    public class MyComboBox : ComboBox
        {
            public MyComboBox()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
              // Repaint here
            }
        }
