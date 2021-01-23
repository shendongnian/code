    class Colourizer 
    {
        private int _current;
        public void Colourize(Func<int, bool> predicate)
        {
            for(int i = _current; current < 161; ++ _current)
            {
               // change labels here
               if(predicate(i))
                   break;
            } 
        }
        public void Reset()
        {
            _current = 0;
        }
    }
    private Colourizer _colourizer = new Colourizer();
    private void Button1_OnClick(object sender, EventArgs args) 
    {
        _colourizer.Colourize((i) => false); // this just does all
    }
