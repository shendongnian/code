    class Encyclopedia : IBook
    {
        public class EncyclopediaEventArgs : EventArgs
        {
        }
        public event EventHandler<EventArgs> PageChanged;
        protected void OnPageChanged(int volume)
        {
            EventHandler<EventArgs> pageChanged = PageChanged;
            if (pageChanged != null) pageChanged(this, new EncyclopediaEventArgs(...));
        }
    }
    public class BookReader
    {
        public void OnPageChanged(object sender, EventArgs e)
        {
            if (sender is Encyclopedia && e is EncyclopediaEventArgs)
            {
                EncyclopediaEventArgs ee = (EncyclopediaEventArgs)e;
            }
            else
            {
            }
        }
    }
