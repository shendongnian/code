    public class catData : ICatData
    {
        public string catName;
        public string modGUID;
        public string versionLocal;
        public string versionServer;
        public bool onServer;
    }
    void allCats()
    {
        List<ICatData> mainCatSet = new List<ICatData>();    
        mainCatSet.Add(new catData { name = "abc", tel = "none"});    
        var catForm = new catalogueSelect(mainCatSet)
    }
