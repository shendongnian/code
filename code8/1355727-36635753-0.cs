    public sealed partial class basket : Page
    {
        private CartService _cartService;
    
        public basket(CartService cartService)
        {
            this.InitializeComponent();
            _cartService = cartService;
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
    
            App app = Application.Current as App;
            var v = int.Parse(textBox.Text); //converting textbox to integer
    
            v = _cartService.storeValue; //variable should be displayed in this textbox     and show "1"
        }
    
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(logorder));
        }
    
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
    
        }
    }
