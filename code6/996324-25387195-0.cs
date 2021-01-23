        public class Question : INotifyPropertyChanged
    {
       //your existing code
        //....
        //.....
        //Add Command to your Question class as below
        MyCommand radioCommand;
        public MyCommand RadioCommand
        {
            get { return radioCommand ?? (radioCommand = new MyCommand(OnRadioCommand, () => true)); } 
        }
        void OnRadioCommand(object obj)
        {
            if (obj != null)
            {
                var checkedRadiochecked = obj.ToString();
                //checkedRadiochecked  will have either Tak or Nie according to 
                //  RadioButton checked
                //do your stuff of changing this object here
            }
        }
    }
