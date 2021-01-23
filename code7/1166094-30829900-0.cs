    class Class1
    {
        private readonly UserControl _userControl;
        public Class1(UserControl userControl)
        {
            _userControl = userControl;
        }
        public void SomeMethod()
        {
            _userControl.MyMethod() etc
        }
    }
