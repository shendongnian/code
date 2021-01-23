    //doesn't depends on specific Entity Data Model
    public class UtilityCase
    {
        public List<EntityObject> Persons = new List<EntityObject>();
 
        private readonly Action<IEnumerable<EntityObject>> _saveImpl;
        public UtilityCase(Action<IEnumerable<EntityObject>> saveImpl)
        {
            _saveImpl = saveImpl;
        }
        ...
   
        public void PersistClear()
        {
            _saveImpl(Persons);
        }
    }
