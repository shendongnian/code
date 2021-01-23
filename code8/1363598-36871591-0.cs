    public class HttpResponse<T> where T : class
    {
        private List<T> _data { set; get; }
        private HttpStatus _status { set; get; }
        public HttpResponse()
        {
            _data = null;
            _status = new HttpStatus();
        }
        public List<T> Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (value != null) _data = value;
            }
        }
        public HttpStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != null) _status = value;
            }
        }
    }
