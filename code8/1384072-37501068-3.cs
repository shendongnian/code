    Public UserControlButton
    {
        private List<IObserver> observers;
        public void addObserver(IObserver observer)
        {
            observers.Add(observer);
        }
        public void button_clickedEvent(object sender, EventArgs e)
        {
            foreach(IObserver observer in observers)
            {
                observer.armySwitchClose(object sender, EventArgs e);
            }
        }
    }
