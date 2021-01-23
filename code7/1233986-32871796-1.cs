    public class MyViewModel : ViewModelBase
    {
        private readonly MyModel myModel = new MyModel();
        public string Name
        {
            get { return myModel.Name; }
            set
            {
                if (SetProperty(() => myModel.Name == value, () => myModel.Name = value))
                {
                    // Do something here since the value was changed.
                }
            }
        }
    }
