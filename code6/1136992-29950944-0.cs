    public BaseClass<T> {
        protected BaseClass()
        {
            this.myDic = new Dictionary<string, List<T>>();
        }
        protected Dictionary<string, List<T>> myDic { get; set; }
    }
    public Type1Class : BaseClass<Type1> {
    }
    public Type2Class : BaseClass<Type2> {
    }
