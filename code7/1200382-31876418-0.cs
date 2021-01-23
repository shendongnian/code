     public void Initialize(ref Dictionary<string, Func<Rootobject>> rootDic)
            {
                Func<Rootobject> shouldFunc = () =>
                {
                    Rootobject root = new Rootobject();
                    root.should = new Should[1];
                    Should objShould = new Should();
                    objShould.match = new Match();
                    objShould.match.pname = "hello";
                    root.should[0] = objShould;
    
                    return root;
                };
    
                Func<Rootobject> mustFunc = () =>
                {
                    Rootobject root = new Rootobject();
                    root.must = new Must[1];
                    Must objMust = new Must();
                    objMust.match = new Match();
                    objMust.match.pname = "hello";
                    root.must[0] = objMust;
    
                    return root;
                };
                rootDic = new Dictionary<string, Func<Rootobject>>();
                rootDic.Add("should", shouldFunc);
                rootDic.Add("must", mustFunc);
            }
