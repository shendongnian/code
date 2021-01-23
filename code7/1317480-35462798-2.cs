    public static void trigger(string evt, dynamic obj){
        Delegate item;
        if(event_list.TryGetValue(evt, out item)){
            // Get MethodInfo and Target
            MethodInfo methodInfo = item.Method;
            object target = item.Target; 
            // Get the parameter list
            var paramList = methodInfo.GetParameters();
            // Get the type of the obj
            var type = obj.GetType();
            // Build the argument list
            var args = new object[paramList.Length];
            for (int index = 0; index < paramList.Length; index++)
            {
                var parameter = paramList[index];
                var name = parameter.Name;
                // Get the value from obj
                var property = type.GetProperty(name);
                var value = property.GetValue(obj, null);
                args[index] = value;
            }
            // Invoke
            methodInfo.Invoke(target, args);
        }
    }
