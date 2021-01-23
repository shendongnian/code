    public partial class Form1 : Form, IObserver<SearchData>
    {
        private IDisposable _unsubscriber;
        SearchForm _frm;
        
        public Form1()
        {
            InitializeComponent();
            _frm = new SearchForm();    
            this.Subscribe(_frm);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _frm.Search();
        }
        public void OnCompleted()
        {
            this.Unsubscribe();
        }
        public void OnError(Exception error)
        {
            throw error;
        }
        public void OnNext(SearchData value)
        {
            searchDataGrid.DataSource = value.Result;            
        }
        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
        public virtual void Subscribe(IObservable<SearchData> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }
    }
