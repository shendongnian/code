        protected bool IsNullOrDefault(object obj)
        {
            bool retval = false;
            if (obj == null)
            {
                retval = true;
            }
            else
            {
                retval = IsEmpty((dynamic)obj);
            }
            return retval;
        }
        protected bool IsEmpty<T>(T value)
        {
            return object.Equals(value, default(T));
        }
