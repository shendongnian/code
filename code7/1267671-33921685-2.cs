        public class YourClassMultiEditWrapper{
            private ICollection<YourClass> _objectsToEdit;
   
            public YourClassMultiEditWrapper(ICollection<YourClass> objectsToEdit)
                _objectsToEdit = objectsToEdit;
            public string SomeProperty {
               get { return _objectsToEdit[0].SomeProperty ; } 
               set { foreach(var item in _objectsToEdit) item.SomeProperty = value; }
            }
        }
        public class YourClass {
           public property SomeProperty {get; set;}
        }
    Advantage is that it is quite simple to do. Disadvantage is that you need to create wrapper for each class you want to edit. 
