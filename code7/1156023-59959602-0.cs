    //'this' Makes this an extension method if you do not want this to be an extension method just remove the 'this' keyword before model
    private static bool IsSame<T,T2>(this T model, T2 model2)
        {
            long changes = 0;
            
            foreach (var pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var secondModelPi = typeof(T2).GetProperty(pi.Name, BindingFlags.Instance | BindingFlags.Public);
                if (secondModelPi != null)
                {
                    if (!pi.GetValue(model).Equals(secondModelPi.GetValue(model2)))
                    {
                        changes++;
                    }
                }
            }
            return changes == 0;
        }
