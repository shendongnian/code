    class LoginGUI
    {
        public static Account acc;
        [...]
    }
    class ProductGUI
    {
        private void addToCartButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(LoginGUI.acc.Fullname);
        }
        [...]
    }
