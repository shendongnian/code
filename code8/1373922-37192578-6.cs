    public class Result
    {
        private List<object> _vaguelist;
        public List<object> vaguelist {
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
    Result a = new Result();
    a.vaguelist.Add("1234");
    a.vaguelist.Add(1234);
