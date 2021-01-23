        public EditBasketPopup(string idBasket)
        {
            InitializeComponent();
            Basket b = control.GetBasket(idBasket);
            //You set the form boxes:
            txtProductName.Text = b.ProductName;
            txtLatestPrice.Text = b.LatestPrice;
            txtQuantity.Text = b.Quantity;
        }
