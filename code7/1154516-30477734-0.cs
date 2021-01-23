    public static class AttributeExtensions
        {
            public static object ToAttributeArray(this DAttributes dealAttr)
            {
                var objectsColl = dealAttr.dAttributes.Select(x => x.Key + "=" + x.Value);
    
                var objArray = objectsColl.Cast<object>();
                return  objArray.ToArray<object>();
    
            }
        }
