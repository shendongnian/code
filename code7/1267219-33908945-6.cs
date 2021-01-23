     public static ExpandoObject ToExpando(this object AnonymousObject)
            {
                dynamic NewExpando = new ExpandoObject();
                foreach (var Property in AnonymousObject.GetType().GetProperties())
                {
                    dynamic Value;
                    if (IsPrimitive(Property.PropertyType))
                    {
                        Value = Property.GetValue(AnonymousObject);
                    }
                    else if (Property.PropertyType.IsArray)
                    {
                        var ArrayProperty = new List<ExpandoObject>();
                        var elements = Property.GetValue(AnonymousObject) as IEnumerable;
                        //is the same as foreach all elements calling to Expando and adding them to elemenstArray
                        if (elements != null)
                            ArrayProperty.AddRange(from object elem in elements select ToExpando(elem));
    
                        Value = ArrayProperty;
                    }
                    else
                    {
                        Value = ToExpando(Property.GetValue(AnonymousObject));
                    }
                    ((IDictionary<string, object>)NewExpando)[Property.Name] = Value;
                }
                return NewExpando;
            }
