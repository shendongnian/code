    if (property.PropertyType.Name.ToLower() == "list`1")
    {
         var users = property.GetValue(MyClass, null) as IList;
         // create instance of list
         users = (IList)typeof(List<>).MakeGenericType(typeof(User)).GetConstructor(Type.EmptyTypes).Invoke(null);
         // create instance of user
         var user = Activator.CreateInstance<User>();
         // put Property "ID" value to 1 or any which you want
         user.GetType().GetProperty("ID").SetValue(user, 1, null);
         // put Property "Name" value to "Name1" or any which you want
         user.GetType().GetProperty("Name").SetValue(user, "Name1", null);
         // set more here
       
         users.Add(user); // add into list
    }
