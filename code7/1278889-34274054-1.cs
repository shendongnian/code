    namespace App3
    {
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void GoToPage_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(SecondPage), new Params() { MyProperty = 42 });
        }
    }
    public class Params
    {
        public int MyProperty { get; set; }
    }
    }
