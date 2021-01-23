        public partial class MyForm : Form
        {
            private MyDisposable myDisposable_;
     
            public MyForm()
            {
                InitializeComponent();
     
                this.myDisposable_ =
                new MyDisposable("Goodbye, World");
            }
        }
 
