      static userCount= 0;
        
        public void page_OnLoad()
        {
            if(!IsPostBack())
                userCount++;
        }
