        public partial class MyForm : Form
        {
            private MyDisposable myDisposable_;
     
            public MyForm()
            {
                InitializeComponent();
     
                this.myDisposable_ =
                new MyDisposable("Goodbye, World");
                this.components.Add(new Disposer(this.OnDispose));
            }
     
            private void OnDispose(bool disposing)
            {
                this.myDisposable_.Dispose();
            }
        }
 
