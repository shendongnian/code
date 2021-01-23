    Person p = new Person();
    p.Name = "Apple";
    
    var urlEncodedString = String.Join("&", p.GetType().GetProperties()
            .Select(property => property.Name + "=" + HttpUtility.UrlEncode(property.GetValue(p, null).ToString()))
            .ToArray());
