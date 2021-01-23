       public static Object GetValue()
       {
           var fl = new firstlevel { sl = new secondlevel { Name = "imran" } };
           Object obj = fl;
           const string path = "fl.sl.Name";
           var part = path.Split('.');
           var type = obj.GetType();
           var firstPart = part[0];
           var secondpart = part[1];
           var thirdpart = part[2];
           var info = type.GetProperty(secondpart);
           if (info == null) { return null; }
           var secondObject = info.GetValue(obj, null);
           return secondObject.GetType().GetProperty(thirdpart).GetValue(secondObject);
       }
