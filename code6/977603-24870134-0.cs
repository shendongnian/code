    class foo
    {
        public void action()
        {
            Debug.WriteLine("Hello");
        }
    
        public void action(Action fnc)
        {
            action();
            fnc();
        }
    }
