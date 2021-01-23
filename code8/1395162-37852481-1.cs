    public class Controller<T> where T : RealmObject, new()
    {
        private Realm realm;
        public Controller()
        {
            this.realm = Realm.GetInstance();
        }
    
        public void Insert(T selfObj)
        {
            this.realm.Write(() => 
                {
                    Debug.WriteLine(typeof(T)); // => "Country".
    
                    this.realm.Manage<T>(selfObj);
                }
            );  // closing paren was missing above too
        }
    }
                
