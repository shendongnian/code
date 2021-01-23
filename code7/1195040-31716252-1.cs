    namespace exampleNamespace
    {
        public partial class YourClass : ClassType
        {
            //  local variables
            private bool booleanVariable;
        
            // class constructor
            public YourClass()
            {
                this.booleanVariable = false;
            }
    .
    .
    .
            //  Your function
            private void CheckFunction()
            {
                if (this.booleanVariable == true)
                    this.MyRadioButton.IsChecked = true;
            }
    .
    .
    .
        }
    }
