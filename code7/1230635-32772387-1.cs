        using System.Windows.Forms; //Above your namespace
    
        public class View : UserControl
        {
            /// <summary>
            ///     Warning! Attempting to use this constructor and host (eg switching views)
            ///     will result in exceptions unless host is manually set
            /// </summary>
            protected View()
            {
            }
            protected View(IHost host) 
            {
                Host = host;
            }
    
            public virtual IHost Host { get; }
        }
    
