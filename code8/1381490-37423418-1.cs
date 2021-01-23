    public partial class MainWindow : MetroWindow
    {
        private void InitLogin()
        {
            using (var lw = new LoginWindow())
            {
                this.Hide();
                lw.ShowDialog();
                if (lw.Status == Status.Success)
                {
                    loginDone = true;
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
    public partial class LoginWindow : MetroWindow, IDisposable
    {
        public Status Status { get; set; }
        // ... 
    }
