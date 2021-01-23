    public static string ABC<T>(T obj) 
        {
            string s=string.Empty;
            //Some code
            if(obj is ClassA)
                s = obj.GetType().GetProperty("Var2").GetValue(obj, null).ToString(); //of classA
            if (obj is ClassB)
            s = obj.GetType().GetProperty("Var4").GetValue(obj,null).ToString(); //of classB
            //Some code
            return s;
        }
