    //Model
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    //ModelWrapper which implements INotifyPropertyChanged if Model doesn't
    //Here you can add additional properties which will serve a View's needs
    class PersonModelWrapper
    {
        private Person _Model;
        //Through this constructor you will create instance of modelwrapper
        //without any conversions
        public PersonModelWrapper (Person model)
        {
            _Model = model;
        }
        public string FirstName 
        { 
            get 
            { 
                return _Model.FirstName; 
            }
            set 
            {
                _Model.FirstName = value; 
            }
        }
        public string LastName
        { 
            get 
            { 
                return _Model.LastName; 
            }
            set 
            {
                _Model.LastName = value; 
            }
        }
        public string FullName
        { 
            get 
            { 
                return _Model.FirstName + " " _Model.LastName; 
            }
        }
      
        //Through this property you will always access current model property
        //without conversions
        public Person Model { get { return _Model; }}
    }
    //ViewModel which used as DataContext in the View
    class PersonViewModel
    {
        private PersonModelWrapper _Wrapper;
        public string Wrapper
        { 
            get 
            { 
                return _Wrapper; 
            }
            set 
            {
                _Wrapper = value; 
            }
        }
    }
