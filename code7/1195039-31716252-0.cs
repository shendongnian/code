    namespace exampleNamespace
    {
        //  local variables
        private bool booleanVariable;
        
        // class constructor
        public PageSurveyN()
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
