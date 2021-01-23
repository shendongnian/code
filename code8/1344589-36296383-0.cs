     public string ErrorCode
        {
            get
            {
                if (!this.request.Completed)
                {
                    return "Incomplete";
                }
                return this.request.Error.ToString();
            }
    
            private set
            {
                 _globalVar = value;
            }
        }
