    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Data;
    using System.Security.Cryptography;
    
    namespace InfestApp
    {
        public sealed class PasswordHash
        {
            const int SaltSize = 16, HashSize = 20, HashIter = 10000;
            readonly byte[] _salt, _hash;
            public PasswordHash(string password)
            {
                new RNGCryptoServiceProvider().GetBytes(_salt = new byte[SaltSize]);
                _hash = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
            }
            public PasswordHash(byte[] hashBytes)
            {
                Array.Copy(hashBytes, 0, _salt = new byte[SaltSize], 0, SaltSize);
                Array.Copy(hashBytes, SaltSize, _hash = new byte[HashSize], 0, HashSize);
            }
            public PasswordHash(byte[] salt, byte[] hash)
            {
                Array.Copy(salt, 0, _salt = new byte[SaltSize], 0, SaltSize);
                Array.Copy(hash, 0, _hash = new byte[HashSize], 0, HashSize);
            }
            public byte[] ToArray()
            {
                byte[] hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(_salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(_hash, 0, hashBytes, SaltSize, HashSize);
                return hashBytes;
            }
            public byte[] Salt { get { return (byte[])_salt.Clone(); } }
            public byte[] Hash { get { return (byte[])_hash.Clone(); } }
            public bool Verify(string password)
            {
                byte[] test = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
                for (int i = 0; i < HashSize; i++)
                    if (test[i] != _hash[i])
                        return false;
                return true;
            }
        }
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void main_B_login_Click(object sender, RoutedEventArgs e)
            {
                //Store a password hash
                PasswordHash shhh = new PasswordHash(Main_T_Password.Text);
                byte[] hashBytes = shhh.ToArray();
    
                //connect to the database
                //connect to the database
                SqlConnection loginConn = null;
                SqlCommand cmd = null;
                SqlDataAdapter sda = null;
                DataTable dt = new DataTable();
    
                loginConn = new SqlConnection("server=localhost;" + "Trusted_Connection=yes;" + "database=Production; " + "connection timeout=30");
                cmd = new SqlCommand("Select Username, Password FROM [User] WHERE Username =@UsernameValue", loginConn);
                loginConn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@UsernameValue", SqlDbType.VarChar).Value = Main_T_Username.Text;
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    // access the first row (index=0) and access the row's column by name
                    if ((string)dt.Rows[0]["Password"] == Main_T_Password.Text)
                    {
                        MessageBox.Show("username and Password = Correct");
                    }
                    else
                    {
                        MessageBox.Show("Password = Wrong");
                    }
                }
                else
                {
                    MessageBox.Show("WrongPass or Username!");
    
    
    
                    loginConn.Close();
                }
            }
    
            private void main_B_Signup_Click(object sender, RoutedEventArgs e)
            {
                RegWindow rWindow = new RegWindow();
                rWindow.Show();
                this.Close();
            }
    
    
    
    
    
            private void Main_T_Username_KeyDown(object sender, KeyEventArgs e)
            {
                if (Main_T_Username.Text == "Username")
                    Main_T_Username.Text = "";
            }
    
            private void Main_T_Username_KeyUp(object sender, KeyEventArgs e)
            {
                if (Main_T_Username.Text == "")
                    Main_T_Username.Text = "Username";
            }
    
            private void Main_T_Password_KeyDown(object sender, KeyEventArgs e)
            {
                if (Main_T_Password.Text == "Password")
                    Main_T_Password.Text = "";
            }
    
            private void Main_T_Password_KeyUp(object sender, KeyEventArgs e)
            {
                if (Main_T_Password.Text == "")
                    Main_T_Password.Text = "Password";
            }
        }
    }
