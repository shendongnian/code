       // since user will enter text value should be string
        public dynamic ParseValue(string value)
        {
            DateTime tempDateTime;
            if (DateTime.TryParse(value, out tempDateTime))
            {
                return tempDateTime;
            }
            int tempInt;
            if(int.TryParse(value, out tempInt))
            {
                return tempInt;
            }
             
            // also process other types like double etc. before falling back to string
            return value;
        }
    }
