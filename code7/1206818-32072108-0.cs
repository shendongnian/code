    public class MyClass
    {
        private static Regex PhoneNumber_Regex { get; set; }
        private static Regex Email_Regex { get; set; }
        static MyClass
        {
            PhoneNumber_Regex = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$");
            Email_Regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$.");
        }
        public void Validate()
        {
            if (!PhoneNumber_Regex.IsMatch(PhonNumb_txBox.Text)) 
                MessageBox.Show("Invalid cellphone number");
            if (!Email_Regex.IsMatch(Email_txBox.Text)) 
                MessageBox.Show("Invalid E-Mail");
        }
    }
