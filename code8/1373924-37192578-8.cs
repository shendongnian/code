    public class Result<T>
    {
        private List<T> _vaguelist = new List<T>();
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
    a.vaguelist.Add("1234");
    Result b = new Result<int>();
    a.vaguelist.Add(1234);
