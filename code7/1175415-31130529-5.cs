     namespace ExtensionMethods
        {
            public static class oMyExtensions
            {
                public int propertyMatches(this MyObject o, MyObject otherObj)
                {
                    int matchesCount = 0;
    
                    if (o.P1 == otherObj.P1) matchesCount++;
                    if (o.P2 == otherObj.P2) matchesCount++;
                    if (o.P3 == otherObj.P3) matchesCount++;
                    if (o.P4 == otherObj.P4) matchesCount++;
    
                    return matchesCount;
                }
            }
        }
