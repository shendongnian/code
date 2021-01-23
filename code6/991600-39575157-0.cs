     var asm = System.Reflection.Assembly.LoadFrom("External.Resources.dll");
     string[] strings = asm.GetManifestResourceNames();
     string myResourceString=null;
     foreach (var res in from s in strings
                                let rm = new ResourceManager(s, asm)
                                select s.Substring(0, s.IndexOf(".resource"))
                                into rst
                                select asm.GetType(rst, false)
                                into type
                                where null != type
                                select type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                                into resources
                                from res in resources
                                where res.PropertyType == typeof(string)
                                select res)
            {
                myResourceString = res.GetValue(null, null) as string;
            }
