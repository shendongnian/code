        public MyPage: Page, IMyView
        {
          
          private Boolean _isInitialized; 
        
          public void Page_Init(Object sender, EventArgs e)
          {
            this._isInitialized = true; 
          }
        
          public IList<User> Users
          {
            get { ... }
            set
            {
              if (this._isInitialized) 
              {
                this.grid.DataSource = value;
                this.grid.DataBound();
              }
            }
          }
        }
