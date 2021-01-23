        public bool Changed(object obj)
        {
            bool result = false;
            lock(Backup_Object_Value)
            {
               if (obj.Equals(Backup_Object_Value)) { }
               else
               {
                  Backup_Object_Value = obj;
                  result = true;
               }
            }
            return result;
        }
