    public T GetSetting<T>(Expression<Func<T>> setting)
    {
         var memberExpression = (MemberExpression) setting.Body;
         var settingName = memberExpression.Member.Name;
         if (string.IsNullOrEmpty(settingName))
             throw new Exception(
                "Failed to get Setting Name " + 
                "(ie Property Name) from Expression");
         var settingDefaultValue = setting.Compile().Invoke();
  
         //Use the method posted in the answer to try and retrieve the
         //setting from Azure / appSettings first, and fallback to 
         //defaultValue if no override was found
         return GetSetting(
                settingName,
                settingDefaultValue);
    }
