    public BaseClass<T>
    {
        protected BaseClasse()
        {
            this.myDic= new Dictionary<string, List<T>>();
        }
        protected Dictionary<string, List<T>> myDic{ get; set; }
    }
