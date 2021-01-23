      public class MyViewModel
    {
        public MyViewModel(MyModel model)
        {
            Model = model;
        }
        public MyModel Model { get; set; }
        public string Description
        {
            get
            {
                return Model.Description;
            }
        }
        public string One
        {
            get
            {
                if (Model.Value == 1)
                    return "X";
                else
                    return string.Empty;
            }
        }
        public string Two
        {
            get
            {
                if (Model.Value == 2)
                    return "X";
                else
                    return string.Empty;
            }
        }
        public string Three
        {
            get
            {
                if (Model.Value == 3)
                    return "X";
                else
                    return string.Empty;
            }
        }
        public string Four
        {
            get
            {
                if (Model.Value == 4)
                    return "X";
                else
                    return string.Empty;
            }
        }
    }
