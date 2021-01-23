    public class MyClass
    {
        private Button btnMyButton;
    
        public Button getMyButton
        {
            get{ return btnMyButton; }
            set{ btnMyButton = value; }
        }
    }
    
        // in some other class
        void ChangeActiveButton(Button newButton)
        {
            MyClass theThing = GetTheThing();
    
            // This doesn't read well...
            theThing.getMyButton = newButton;
        }
