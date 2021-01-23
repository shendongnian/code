    Public Interface IObserver
    {
        void armySwitchClose(object sender, EventArgs e);
    }
    Public UserControl1: Observer
    {
        void armySwitchClose(object sender, EventArgs e)
        {
            //implementation UC1
        }
    }
    Public UserControl2: Observer
    {
        void armySwitchClose(object sender, EventArgs e)
        {
            //implementation UC2
        }
    }
