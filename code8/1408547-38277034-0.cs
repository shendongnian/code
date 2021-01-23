    class MyEventArgs : EventArgs
    {
        public string Text { get; private set; }
        public MyEventArgs(string text)
        {
            Text = text;
        }
    }
