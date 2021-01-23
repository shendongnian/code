        object CallFunction(string[] fileList , string eventName , object[] parameters){
            foreach(var file in fileList)
            {
                Assembly assem = Assembly.LoadFrom(file);
                foreach(var t in assem.GetTypes())
                {
                    var methodInfo = t.GetMethod(eventName);
                    if(methodInfo != null)
                    {
                        var obj = Activator.CreateInstance(t);
                        return methodInfo.Invoke(obj , parameters);
                    }    
                }
            }
            
            return null;
        }
