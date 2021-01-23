     class Factory()
     {
          object create(string value)
          {
                   	 
    	       Type type = Type.GetType("SchoolSerice");
    	       Object obj = Activator.CreateInstance(type);
    	       MethodInfo methodInfo;
    
               string pattern = "([^\\/]+)\\/([^\\/]+)";
               string methodName = "";
               List<int> argsList = new List<int>();
               int[] argsArray;
     
               foreach (Match m in Regex.Matches(value, pattern)) 
               {
                   methodName="get"+char.ToUpper(m.Groups[1].Value[0]) + m.Groups[1].Value.Substring(1);
                   argsList.Add(Int32.Parse(m.Groups[2].Value));
               }
               argsArray=argsList.ToArray();
               methodInfo = type.GetMethod(methodName);
               return new methodInfo.Invoke(obj, argsArray);
           
          }
    }
