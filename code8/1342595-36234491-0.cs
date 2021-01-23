    public class MyVm {
        public MyVm() {
            this.CreateCommand = new Command((sender) =>
            {
                Debug.WriteLine("Hello");
            });
        }
        public ICommand CreateCommand { get; private set; }
    }
    ...
    
    public SetsPage() {
            var vm = new MyVm();
            this.BindingContext = vm;
            InitializeComponent();
    ...
