       public string Error
       {
           get { return string.Empty; }
       }
        public string this[string propertyName]
        {
            get { return GetErrorForProperty(propertyName); }
        }
        private string GetErrorForProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "ModelNumber":
                    if (test bool property here)
                    {
                       //if false
                       return "string";
                    }
                    else
                    {
                       //if true
                       return string.Empty;
                    }
                default:
                    return string.Empty;
         }
