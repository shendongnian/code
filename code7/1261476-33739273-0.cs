    bool IsEqual(object obj)
        {
            var type = this.GetType();
            bool SameObj = true;
            //for each public property from your class
            type.GetProperties().ToList().ForEach(prop =>
            {
                //dynamically checks there equals
                if (!prop.GetValue(this, null).Equals(prop.GetValue(obj, null)))
                {
                    SameObj = false;
                }
            });
            return SameObj;
        }
