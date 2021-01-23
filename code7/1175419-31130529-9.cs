     namespace ExtensionMethods
        {
            public static class oMyExtensions
            {
                public static int propertyMatches(this MyObject o, MyObject otherObj)
                {
                    return (x.Property1 == testObject.Property1 ? 1 : 0)
                    + (x.Property2 == testObject.Property2 ? 1 : 0)
                    + (x.Property3 == testObject.Property3 ? 1 : 0)
                    + (x.Property4 == testObject.Property4 ? 1 : 0)
   
                }
            }
        }
