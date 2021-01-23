    private class MyAppContext : ApplicationContext
    {
        public MyAppContext()
            :base(new MainForm())
        {
            //Exit delegate
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            MainForm.Show();
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup code...
        }
    }
