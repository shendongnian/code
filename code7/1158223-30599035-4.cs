        public EditBasketPopup(Basket b)
        {
            InitializeComponent();
            txtProductName.Text = b.ProductName;
            txtLatestPrice.Text = b.LatestPrice;
            txtQuantity.Text = b.Quantity;
            this.Text = "Basket - Editor";
        }
