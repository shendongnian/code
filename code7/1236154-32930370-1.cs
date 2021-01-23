    namespace CustomControlTest
    {
        public partial class MyTextField : TextBox
        {
            public MyTextField()
            {
                InitializeComponent();                            
            }    
          
            private string _ghostText;
		    public string GhostText 
  		    {
			    get
			    {
				    return _ghostText;
			    }
			    set
			    {
				    this.Text = value;
				    _ghostText = value;
			    }
		    } 
            
        }
    }
