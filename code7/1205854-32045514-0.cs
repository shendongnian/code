      public class MyForm {
        protected override void WndProc(ref Message m) {
          const int WM_SYSCOMMAND = 0x0112;
          const int SC_MAXIMIZE = 0xF030;
          // When form is going to be maximized    
          if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MAXIMIZE)) {
            m.Msg = 0; // <- we don't want a standard maximization
            //TODO: tell Windows here what to do when user want to maximize the form
    
            // Just a sample (pseudo maximization)
            Location = new Point(50, 50);
            Size = new Size(Screen.GetWorkingArea(this).Width - 2 * Left, Screen.GetWorkingArea(this).Height - 2 * Top);
          }
    
          base.WndProc(ref m);
        } 
        ...
      }
