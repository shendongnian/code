        try
        {
            var existingUser = db.Users.Find(user.UserId); //or use db.Users.FirstOrDefault(...)
			if(existingUser == null)
			{
				return false;
			}                 
			
			Type nType = user.GetType();
            PropertyInfo[] newValues = nType.GetProperties();
			
			foreach (PropertyInfo prop in newValues)
			{
			    var propVal = prop.GetValue(user,null);
                if(propVal!= null)
				{
				    var eProp = existingUser.GetType().GetProperty(prop.Name);
					if(eProp != null)
					{
					   eProp.SetValue(existingUser, propVal, null);
					}
				}				
			}        
            db.SaveChanges();
            return (true);
        }
        catch { }
        return (false);
