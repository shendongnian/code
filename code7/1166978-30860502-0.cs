    public class NewGUIForm : Form
    {
        static System.Threading.SynchronizationContext _context = null;
        ... 
        protected override void OnLoad(EventArgs e)
		{
            _context = WindowsFormsSynchronizationContext.Current;
			base.OnLoad(e);
		}
        ...
       public static void ReadCallback(IAsyncResult ar)
       {
           ...
           System.Threading.SendOrPostCallback method = new System.Threading.SendOrPostCallback((o) =>
					{
                            Tool_Logging tl = new Tool_Logging();
                            tl.ShowDialog();
					});
           _context.Post(method, input);
           ...
       }
    }
