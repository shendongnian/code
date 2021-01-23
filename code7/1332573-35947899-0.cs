     public class ObservableObject<T> : IList, IListSource
    {
        protected BindingSource src = null;
        List<ListControl> Subscribers;
        ObservableCollection<T> Data = new ObservableCollection<T>();
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }
        public int Count
        {
            get
            {
                return Data.Count;
            }
        }
        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public bool ContainsListCollection
        {
            get
            {
                return true;
            }
        }
        object IList.this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                Data[index] = (T)value;
            }
        }
        public T this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                Data[index] = value;
            }
        }
        public ObservableObject()
        {
            Data.CollectionChanged += Domains_CollectionChanged;
            Subscribers = new List<ListControl>();
            src = new BindingSource();
            src.DataSource = Data;
        }
        private void Domains_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
             src.ResetBindings(false);
        }
        public virtual void Subscribe(ListBox ctrl)
        {
            this.Subscribers.Add(ctrl);
            //ctrl.DataBindings.Add(new Binding("SelectedValue", src, "Name",
            //                    true, DataSourceUpdateMode.Never));
            ctrl.DataSource = src;
        }
        public int Add(object value)
        {
            Data.Add((T)value);
            return Data.Count - 1;
        }
        public bool Contains(object value)
        {
            return Data.Contains((T)value);
        }
        public void Clear()
        {
            Data.Clear();
        }
        public int IndexOf(object value)
        {
            return Data.IndexOf((T)value);
        }
        public void Insert(int index, object value)
        {
            Data.Insert(index, (T)value);
        }
        public void Remove(object value)
        {
            Data.Remove((T)value);
        }
        public void RemoveAt(int index)
        {
            Data.RemoveAt(index);
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public IEnumerator GetEnumerator()
        {
            return Data.GetEnumerator();
        }
        public IList GetList()
        {
            return Data;
        }
    }
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                this._name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
    }
    public class CSR : BaseModel
    {
        public override string ToString()
        {
            return Name;
        }
    }
    public class Domain : BaseModel
    {
        public ObservableObject<CSR> CSRs { get; set; }
        public Domain()
        {
            CSRs = new ObservableObject<CSR>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Server : BaseModel
    {
        public ObservableObject<Domain> Domains { get; set; }
        public Server()
        {
            Domains = new ObservableObject<Domain>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class DataModel : BaseModel
    {
        public ObservableObject<Server> Servers
        {
            get; set;
        }
        public DataModel()
        {
            Servers = new ObservableObject<Server>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
