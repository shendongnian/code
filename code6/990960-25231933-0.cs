        public object walkObjectConstructor(Type t, ref dynamic x)
        {
            foreach (var p in t.GetRuntimeProperties())
            {
                /* upper level objects */
                if (p.PropertyType.IsClass && p.PropertyType.Assembly == t.Assembly)
                {
                    Debug.WriteLine( p.Name );
                    object _class = Activator.CreateInstance( p.PropertyType );
                    walkObjectConstructor(p.PropertyType, ref _class);
                    x.GetType().GetProperty(p.Name).SetValue(x, _class, null);
                }
                /* inside the last upper level object */
                else
                {
                    Debug.WriteLine( "\t" + p.Name);
                    x.GetType().GetProperty(p.Name).SetValue(x, defaultVal(p.PropertyType), null);
                    return null;
                }
            }
            return x;
        }
