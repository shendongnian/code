        class RComparer : IEqualityComparer<object>
        {
            public bool Equals(object x, object y)
            {
                var xPeriodProperty = x.GetType().GetProperty("Period");
                var yPeriodProperty = y.GetType().GetProperty("Period");
                if (xPeriodProperty != null && yPeriodProperty != null)
                {
                    var xPeriod = (string)xPeriodProperty.GetValue(x);
                    var yPeriod = (string)yPeriodProperty.GetValue(y);
                    return xPeriod == yPeriod;
                }
                else
                    return base.Equals(y);
            }
            public int GetHashCode(object obj)
            {
                var periodProperty = obj.GetType().GetProperty("Period");
                if (periodProperty != null)
                    //This will essentially hash the string value of the Period
                    return periodProperty.GetValue(obj).GetHashCode();
                else
                    return obj.GetHashCode();
                ;
            }
        }
