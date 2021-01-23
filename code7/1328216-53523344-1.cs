    public class ExtendedLabel : Label
    {
        private event EventHandler click;
        public string Name
        {
            get; set;
        }
        public void DoClick()
        {
            click?.Invoke(this, null);
        }
        public event EventHandler Clicked
        {
            add
            {
                lock (this)
                {
                    click += value;
                    var g = new TapGestureRecognizer();
                    g.Tapped += (s, e) => click?.Invoke(s, e);
                    GestureRecognizers.Add(g);
                }
            }
            remove
            {
                lock (this)
                {
                    click -= value;
                    GestureRecognizers.Clear();
                }
            }
        }
    }    
