     public ViewModel()
            {            
                MyCollection.CollectionChanged += MyCollection_CollectionChanged;            
                
                MyCollection.Add(new Class1("Eins", 1));
                MyCollection.Add(new Class1("Zwei", 2));
                MyCollection.Add(new Class1("Drei", 3));
            }
    
            void MyCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                foreach (var v in e.NewItems)
                    ((Class1)v).PropertyChanged += Class1_PropertyChanged;
            }
    
            void Class1_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                // if all validations runs good here
                canHello = true;
            }
        ...
        }
