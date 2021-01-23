    Type t = typeof(MyClass);
    PropertyInfo[] props = t.GetProperties();
    foreach (PropertyInfo p in props) {
        NowThatsAnAttribute attr = p.GetCustomAttributes(false)
            .OfType<NowThatsAnAttribute>()
            .FirstOrDefault();
        if (attr != null) {
            string propName = p.Name;
            string attrValue = attr.HeresMyString;
            switch (propName) {
                case "ThingyA":
                    //TODO: Do something for ThingyA
                    break;
                case "ThingyB":
                    //TODO: Do something for ThingyB
                    break;
                default:
                    break;
            }
        }
    }
