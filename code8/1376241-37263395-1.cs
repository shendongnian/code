        public virtual string GetEnumName(object value)
        {
            // standard argument guards...
 
            Array values = GetEnumRawConstantValues();
            int index = BinarySearch(values, value);
 
            if (index >= 0)
            {
                string[] names = GetEnumNames();
                return names[index];
            }
 
            return null;
        }
