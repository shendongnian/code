    public class Entity
    {
        // that's what stored in the DB, and shouldn't be accessed directly
        public string SomeListOfValuesStr { get; set; }
        [NotMapped]
        public StringBackedList<string> SomeListOfValues 
		{
            get
            {
				// this can't be created in the ctor, because the DB isn't read yet
                if (_someListOfValues == null)
				{
					 // the backing property is passed 'by reference'
                    _someListOfValues = new StringBackedList<string>(() => this.SomeListOfValuesStr);
				}
                return _someListOfValues;
            }
        }
        private StringBackedList<string> _someListOfValues;
    }
