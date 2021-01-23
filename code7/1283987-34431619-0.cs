    public class FooBusiness
    {
        private IBarDataHandler _barDatahandler = new BarDatahandler();
        
        public IBarDataHandler BarDatahandler
        {
            get { return _barDatahandler; }
            set { _barDatahandler = value; }
        }
        public int Search(int a)
        {
            return _barDatahandler.Search(a);
        }
    }
