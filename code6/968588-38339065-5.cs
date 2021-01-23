        public MvcApplication() // constructor
        {            
            PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
            EndRequest += new EventHandler(OnEndRequest);
        } 
        protected void OnPreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContextProvider.OnBeginRequest();   // preserves HttpContext.Current for use across async/await boundaries.            
        }
        protected void OnEndRequest(object sender, EventArgs e)
        {
            HttpContextProvider.OnEndRequest();
        }
