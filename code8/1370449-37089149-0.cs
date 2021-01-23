        public void ChangeSomeOtherString()
        {
            BusinessLogicClass.GetInstance().ChangeSomeOtherString();
            OnPropertyChanged("SomeOtherString");    // Add this line
        }
