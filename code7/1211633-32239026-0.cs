    public partial class MyTestView : UserControl {
      public MyTestView() {
          InitializeComponent();
          this.Loaded += OnLoaded;
      }
      private void OnLoaded( ... ){
           var vm = DataContext as MyTestViewModel;
           Debug.Assert(vm != null); // is always null!         
      }
     
    }
