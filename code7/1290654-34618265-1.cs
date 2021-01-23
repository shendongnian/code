        public string Error
        {
            get
            {
                return null;
            }
        }
    
        public string this[string name]
        {
            get
            {
                string result = null;
    
                if (name == "Age")
                {
                    if (this.age < 0)
                    {
                        result = "Age can't be less then zero";
                    }
                    if(this.age > 30)
                    {
                        result = "Huh, no, too old for me";
                    }                   
                }
                return result;
            }
        }
