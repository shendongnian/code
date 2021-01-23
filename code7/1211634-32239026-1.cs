    public partial class MyTestView : UserControl {
      public MyTestView() {
          InitializeComponent();
         
      }
       
       public MyTestViewModel ViewModel{
          return (MyTestViewModel)Datacontext;
       }
     
    }
