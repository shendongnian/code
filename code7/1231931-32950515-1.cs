    public void OnInitComplete(string message)
            {
                this.Initialized = true; 
                this.Facebook.OnInitComplete(message);          
            }
