    class Login : Form
    {
        TextBox User;
        TextBox Pass;
        public Login()
        {
            User = new TextBox();
            User.Bounds = new Rectangle(5, 5, 100, 20);
            Controls.Add(User);
            Pass = new TextBox();
            Pass.Bounds = new Rectangle(5, 25, 100, 20);
            Controls.Add(Pass);
            Button ok = new Button();
            ok.Text = "OK";
            ok.DialogResult = DialogResult.OK;
            ok.Bounds = new Rectangle(5, 50, 100, 20);
            Controls.Add(ok);
            Text = "Login";
        }
        public static DialogResult Show(out string user, out string pass)
        {
            Login self = new Login();
            DialogResult ret = self.ShowDialog();
            user = self.User.Text;
            pass = self.Pass.Text;
            return ret;
        }
    }
