     public static Rootobject getobject(string op)
            {
                Dictionary<string, Func<Rootobject>> rootDic = new Dictionary<string,Func<Rootobject>>();
                Rootobject root = new Rootobject();
                root.InitialIze(ref rootDic);
    
                if(rootDic.Count > 0)
                return rootDic[op].Invoke();
    
                return new Rootobject();
            }
