     class Program
        {
            static void Main(string[] args)
            {
                B obj = new B();  
            }
        }
        public class A
        {
            public static ObservableCollection<object> MyCollection = new ObservableCollection<object>();
        }
        public class B
        {
            public B()
            {
                A.MyCollection.CollectionChanged += Func_CollectionChanged;
                A.MyCollection.Add(1);
            }
    
            private void Func_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                // do some stuff here
            }
        }
