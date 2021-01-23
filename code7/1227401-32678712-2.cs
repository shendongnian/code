    class Cat
    {
        string name;
        LiveString _type;
        public LiveString type {
            get 
            { 
                return _type;
            }
            set 
            {
                _type.Value = value.Value;
            }
        }
        
        public Cat(string name, string type){this.name= name; this._type = type;}
    
        public override string ToString()
        {
            return name;
        }
    }
