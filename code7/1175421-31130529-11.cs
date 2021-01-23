     public static class oMyExtensions
            {
                public static int propertyMatches(this MyObject o, MyObject otherObj)
                {
                    return (o.P1 == otherObj.P1 ? 1 : 0)
                    + (o.P2 == otherObj.P2 ? 1 : 0)
                    + (o.P3 == otherObj.P3 ? 1 : 0)
                    + (o.P4 == otherObj.P4 ? 1 : 0);
    
                }
            }
