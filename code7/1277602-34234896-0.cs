    public enum ScreenOption
    {
        Register,
        AlterRegister,
        ViewRegister
    }
    public class frmRegisterScreen
    {
        public frmRegisterScreen(ScreenOption option)
        {
            switch (option)
            {
                case ScreenOption.ViewRegister:
                    //set the database connection and the Sql command to be used
                    string conString = "Server = .\\sqlexpress; trusted_connection = yes; database=he_dados;";
                    SqlConnection con = new SqlConnection(conString);
                    break;
                ...
            }
        }
    }
    var frmRegister = new frmRegisterScreen(ScreenOption.ViewRegister);
    frmRegister.Show();
