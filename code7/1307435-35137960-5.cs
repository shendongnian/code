    public class IndexViewModel
    {
        private IEnumerable<string> _avlOpt;
        public IEnumerable<string> AvailableOptions
        {
            get { return _avlOpt; }
            set { _avlOpt = value; }
        }
        public IndexViewModel()
        {
            List<string> lstString = new List<string>();
            for (int i=1;i<5;i++)
            {
                lstString.Add(@"<h" + i.ToString() + ">Test</h" + i.ToString() + ">");
            }
            AvailableOptions = lstString;
        }
    }
