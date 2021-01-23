            Func<object, object> getPeriodKey = first =>
            {
                var periodProperty = first.GetType().GetProperty("Period");
                return periodProperty.GetValue(first);
            };
            var temp = r1.GroupJoin(r2, getPeriodKey, getPeriodKey, (obj, tInner) =>
            {
                dynamic right = tInner.FirstOrDefault();
                if (right == null)
                    return (object)(new
                    {
                        Period = ((dynamic)obj).Period,
                        Imported = ((dynamic)obj).Imported,
                    });
                else
                    return (object)(new
                    {
                        Period = ((dynamic)obj).Period,
                        Imported = ((dynamic)obj).Imported,
                        Dissolution = (int?)right.Dissolution,
                    });
            });
            var merged = temp.Union(r2, new RComparer());
