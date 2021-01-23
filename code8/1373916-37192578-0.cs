    public Result<T>
    {
        private List<T> _vaguelist;
        public List<T> vaguelist {
            get
            {
                return _vaguelist;
            }
            set
            {
                _vaguelist = value;
            }
        }
    }
    Result a = new Result<string>();
    a.vaguelist.add("1234");
    Result b = new Result<int>();
    a.vaguelist.add(1234);
