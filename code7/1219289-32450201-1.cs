    if (property.PropertyType.Name.ToLower() == "list`1")
    {
         if (property.PropertyType.Name.ToLower() == "list`1")
         {
              var type = property.PropertyType;
              var it = type.GetGenericArguments()[0];
              var users = Activator.CreateInstance(type); // list of user
              var user = Activator.CreateInstance(it);    //user
              user.GetType().GetProperty("ID").SetValue(user, 1, null);
              user.GetType().GetProperty("Name").SetValue(user, "Name1", null);
              var add = type.GetMethod("Add");
              add.Invoke(users, new[] { user });
         }
    }
