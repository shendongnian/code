    public partial class Login : Form
    {
        public static int CurrentUserID = -1;
        public Login()
        {
            ......
        }    
       
    private bool login_validation(string email, string pass)
    {
        .....
        if (login.Read())
        {
            Login.CurrentUserID = login.GetInt(login.GetOrdinal("ID"));
            conn.Close();
            return true;
        }
        else
        {
            conn.Close();
            return false;
        }
    }
