    public class Form2 ...
    {
        private Form mainmenu
     
        public Form2(Form mainmenu)
        {
            this.mainmenu = mainmenu
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            mainmenu.Show();
            mainmenu.Refresh();
            Thread.Sleep(100);
            this.Hide();
        }
    }
