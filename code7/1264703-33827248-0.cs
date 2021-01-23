    public override Dictionary<string, object> dictionary
        {
            get
            {
               return fn(); 
            }
            set 
            {
                setTest(strKey,objValue);
            }
        }
     
        public void setTest(string strKey, object objValue)
        {
            param[strKey] = objValue;
        }
