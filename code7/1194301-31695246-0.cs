       protected override void WndProc(ref Message message)
       {
           switch (message.Msg)
           {
               case 0x84: // WM_NCHITTEST
                   message.Result = (IntPtr)(-1); // HTTRANSPARENT;
                   return;
           }
           base.WndProc(ref message);
           return;
       }
