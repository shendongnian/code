     static bool ConvertToBool(object Dnull)
            {
                try
                {
                    DBNull a = (DBNull)Dnull;
                    string u = a.ToString();
    
                    if (u.Length > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (InvalidCastException e)
                {
                    return false;
                }
     
            }
