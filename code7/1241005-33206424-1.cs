        public class Cont
        {
            public string Contact { get; set; }
            public string Age { get; set; }
        }
    
        public class ContItem
        {
            public string Key { get; set; }
    
            private ObservableCollection<Cont> _contactColl;
            public ObservableCollection<Cont> ContactColl
            {
                get
                {
                    if (_contactColl == null)
                        _contactColl = new ObservableCollection<Cont>();
                    return _contactColl;
                }
    
            }
        }
    
        public class TestClass
        {
            public ObservableCollection<Cont> Contlist = new ObservableCollection<Cont>();
            private ObservableCollection<ContItem> _groupedCollection;
            public ObservableCollection<ContItem> GroupedCollection
            {
                get
                {
                    if (_groupedCollection == null)
                        _groupedCollection = new ObservableCollection<ContItem>();
                    return _groupedCollection;
                }
            }
    
            public void SetInitialCollection()
            {
                //Add the existing items in ContactList (if any) to a grouped collection.
    
                var keyList = Contlist.GroupBy(c => c.Age).Select(g => g.Key);
                foreach (var key in keyList)
                {
                    var contItem = new ContItem();
                    contItem.Key = key;
                    var contList = Contlist.Where(c => c.Age == key);
                    foreach (var item in contList)
                    {
                        contItem.ContactColl.Add(item);
                    }
                    GroupedCollection.Add(contItem);
                }
    
            }
    
            public void AddNewItem()
            {
                var cont = new Cont();
                cont.Age = "32";
                cont.Contact = "";
                var contItem = GroupedCollection.FirstOrDefault(g => g.Key == cont.Age);
                if (contItem != null)
                {
                    contItem.ContactColl.Add(cont);
                }
                else
                {
                    contItem = new ContItem();
                    contItem.Key = cont.Age;
                    contItem.ContactColl.Add(cont);
                    GroupedCollection.Add(contItem);
                }
            }
    
            public void DeleteItem(Cont cont)
            {
                var contItem = GroupedCollection.FirstOrDefault(g => g.Key == cont.Age);
                if (contItem != null)
                {
                    if (contItem.ContactColl.Contains(cont))
                    {
                        contItem.ContactColl.Remove(cont);
                    }
                }
            }
        }
    <CollectionViewSource x:Key="group" Source="{Binding GroupedCollection}"
                    ItemsPath="ContactColl" IsSourceGrouped="True" />
