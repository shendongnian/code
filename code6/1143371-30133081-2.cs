          foreach (BaseMember bm in members)
            {
                if (Username == bm.username)
                {  
                    Type type = bm.GetType();
    
                    PropertyInfo prop = type.GetProperty(parameter);
    
                    prop.SetValue (bm, newValue, null);
                }
            }
