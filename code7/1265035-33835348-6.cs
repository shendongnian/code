    string[] PropertyNames = new string[] { "IsActiveApp1", "IsActiveApp2" };
    System.Type MyModelInfo = typeof(MyModel);
           
    PropertyNames.SelectMany(prop => MyModelInfo.GetProperty(prop).GetCustomAttributes(true))
        .ToList().ForEach((attr) =>
            {
                 Console.WriteLine(((System.ComponentModel.DisplayNameAttribute)attr).DisplayName);
            });
