    public class MainWindowVM:ViewModelBase
    {
        public MainWindowVM()
        {
            LoadData();
        }
        private void LoadData()
        {            
            ObservableCollection<Human> coll = new ObservableCollection<Human>();
            for (int indexLoop = 0; indexLoop < 5; indexLoop++)
            {
                if (indexLoop % 2 == 0)
                {
                    coll.Add(new Sportsman() {FirstName=indexLoop.ToString(), LastName=indexLoop.ToString()});
                }
                else
                {
                    coll.Add(new Employee() { FirstName = indexLoop.ToString(), LastName = indexLoop.ToString()});
                }                
            }
            CompositeCollection compositeColl = new CompositeCollection();
            compositeColl.Add(new CollectionContainer() { Collection = coll });
            FooData = compositeColl;
        }
        private CompositeCollection fooData;
        public CompositeCollection FooData
        {
            get { return fooData; }
            set
            {
                fooData = value;
            }
        }
    }
