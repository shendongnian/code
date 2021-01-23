    public void ReflectIntoModel<T>(Dictionary<string, object> dic)
            {
                T m = (T)Activator.CreateInstance(typeof(T));
                var prop = typeof(T).GetProperties();
    
                foreach (var a in prop)
                {
                    dynamic val;
                    if (dic.TryGetValue(a.Name, out val))
                        a.SetValue(m, val);
                }
            }
