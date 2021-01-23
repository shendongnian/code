private void buttonCreate_Click(object sender, EventArgs e)
{
    using (var d = new GetNewPasswordDialog())
    {
        if (d.DialogResult == DialogResult.OK)
        {
            var newPassword = d.Password;
            var salt = CreateRandomSalt(33);
            var hash = GeneratePasswordHash(newPassword, salt);
            
            System.Diagnostics.Debug.WriteLine(hash);
            System.Diagnostics.Debug.WriteLine(salt);
            // save the hash & salt
            // using application config as an example
            Properties.Settings.Default.Hash = hash;
            Properties.Settings.Default.Salt = salt;
            Properties.Settings.Default.Save();
        }
    }
}
private void buttonVerify_Click(object sender, EventArgs e)
{
    // The change PIN number has a problem and the pin number 
    // needs to be on a database or a text file in order to be updated correctly
    if (textBox1.TextLength != 0 && textBox1.TextLength < 5)
    {
        message.Text = Properties.Resources.EnterPin;
        // read in the current password hash and salt from storage
        var savedSalt = Properties.Settings.Default.Salt;
        var savedHash = Properties.Settings.Default.Hash;
        // get the pin number that was entered and generate a hash using the saved salt
        var currentPIN = textBox1.Text.Trim();
        var currentHash = GeneratePasswordHash(currentPIN, savedSalt);
        if (string.Compare(savedHash, currentHash) == 0)
        {
            message.Text = "Your PIN is correct";
            // TODO: Allow user to change PIN
            buttonCreate.Enabled = true;
        }
        else
        {
            message.Text = "The PIN you have entered is not correct please try again!  ";
        }
    }
    else
    {
        message.Text = "Please enter a valid PIN";
    }
}
private string CreateRandomSalt(int length)
{
    // Generate a random salt
    var salt = new byte[length];
    using (var csprng = new RNGCryptoServiceProvider())
    {
        csprng.GetBytes(salt);
    }
    return Convert.ToBase64String(salt);
}
private string GeneratePasswordHash(string password, string salt)
{
    using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt)))
    {
        pbkdf2.IterationCount = 1000;
        var hash = pbkdf2.GetBytes(50);
        return Convert.ToBase64String(hash);
    }
}
  [1]: https://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider.aspx
  [2]: https://msdn.microsoft.com/en-us/library/system.security.cryptography.sha256managed(v=vs.110).aspx
