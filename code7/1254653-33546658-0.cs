    protected override void WndProc(ref Message m)
    {
        //134 = WM_NCACTIVATE
        if (m.Msg == 134)
        {       
            //Check if other app is activating - if so, we do not close         
            if (m.LParam == IntPtr.Zero)
            {                    
                 if (m.WParam != IntPtr.Zero)
                 {                     
                     //Other form in our app has focus
                 }
            }
         }                     
                        
         base.WndProc(ref m);
    }
