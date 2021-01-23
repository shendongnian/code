    public class MyButton : Button
    {
        private event EventHandler MyClick;
        public new event EventHandler Click
        {
            add
            {
                MyClick += value;
                base.Click += value;
            }
            remove
            {
                MyClick -= value;
                base.Click -= value;
            }
        }
        public Delegate[] GetClickHandlers()
        {
            return MyClick?.GetInvocationList();
        }
    }
