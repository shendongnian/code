        public event raiseEventEventHandler raiseEvent;
        public void raiseEventActivate()
        {
            if(raiseEvent != null)
            {
                raiseEvent(this, new EventArgs());
            }
        }
