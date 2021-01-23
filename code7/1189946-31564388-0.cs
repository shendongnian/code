    private class SomeClass
    {
        private MovieData _data;
		
        public MovieData Data { get { return _data; } set { _data = value; } }
        public string DataString 
        { 
            get { return _data.ToString(); }
            set {
                switch (value){
                    case "Name":
                        _data = MovieData.Name;
                        break;
                    case "Type":
                        _data = MovieData.Type;
                        break;
                    // etc.
                }
            }
        }
    }
