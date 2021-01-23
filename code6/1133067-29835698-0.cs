        bool myBool = true;
        bool newBool;
        public void Main()
        {
            MyFunction( newBool = (aFunctionThatReturnsABool == true) ? true: false);
        }
        public void MyFunction (bool aBool)
        {
            // stuff based on the bool
        }
