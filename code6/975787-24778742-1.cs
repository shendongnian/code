    public static Object GetValue()
      {
    
            var fl = new firstlevel { sl = new secondlevel { Name = "sandy" } };
            Object obj = fl;
            const string path = "fl.sl.Name";
            String[] part = path.Split('.');
            Type type = obj.GetType();
            string firstPart = part[0];
            string secondpart = part[1];
            string thirdpart = part[2];
            System.Reflection.PropertyInfo info = type.GetProperty(secondpart);
            if (info == null) { return null; }
           
            System.Reflection.PropertyInfo info1 = info.PropertyType.GetProperty(thirdpart);
            if (info1 == null) { return null; }
            
            return info1.GetValue(fl.sl, null);
    }
