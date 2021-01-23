    public static bool IsValidGuestInfo(string firstName, string lastName, string email, string hotel)
    {
         var isValidFirstName = !string.IsNullOrWhiteSpace(txtFirstName.Text)
         var isValidLastName = !string.IsNullOrWhiteSpace(txtLastName.Text)
         var isValidEmail = !string.IsNullOrWhiteSpace(txtEmail.Text)
         var isValidHotel = !string.IsNullOrWhiteSpace(txthotel.Text))
         
         return isValidFirstName && isValidLastName && isValidEmail && isValidHotel;
    }
