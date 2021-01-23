    void Main()
    {
      var form = new Form();
      form.Load += (s, _) => Application.AddMessageFilter(new MyFilter((Form)s));
      
      var pnl = new Panel();
      pnl.Controls.Add(new Button());
      form.Controls.Add(pnl);
      
      Application.Run(form);
    }
    
    public class MyFilter : IMessageFilter
    {
      Form form;
      
      public MyFilter(Form form)
      {
        this.form = form;
        this.form.Disposed += (_, __) => Application.RemoveMessageFilter(this);
      }
    
      public bool PreFilterMessage(ref Message msg)
      {
        const int WM_LMOUSEDOWN = 0x0201;
        
        if (msg.Msg == WM_LMOUSEDOWN && msg.HWnd != IntPtr.Zero 
            && Control.FromHandle(msg.HWnd).TopLevelControl == form)
        {
          Console.WriteLine("Hi!");
        }
        
        return false;
      }
    }
