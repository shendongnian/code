    public class MyClass
    {
        //indexer (could use int or anything else that your underlying collection supports)
        public string this[string index]
        {
            get
            {
                 //retrieve from internal cache/collection/etc based on index
            }
            set
            { 
                 //set internal cache/collection/etc based on index and value
            }
        }
    }
