    using second;
    namespace first_main
    {
       public partial class MainWindow : MetroWindow
       {
          public MainWindow()
          {
            var second = new funkcijos();
            funkcijos.someFuction();
          }
        }
    }
    namespace second
    {
       public class funkcijos
       {
          public funkcijos()
          {
          }
          public void someFuction()
          {
                MessageBox.Show("I use function in MainWindow class, from function class");
          }
        }
    }
