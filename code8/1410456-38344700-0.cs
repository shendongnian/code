     using Microsoft.VisualBasic;
    namespace registryConnection
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected void SaveConnectionString()
        { 
          
            Interaction.SaveSetting("Projectname", "Connection", "Default",       Fullset_of_your_connection_string);
            Interaction.SaveSetting("Projectname", "dbname", "Default", dbname);
            Interaction.SaveSetting("Projectname", "uname", "Default",     dn_uname);
            Interaction.SaveSetting("Projectname", "pass", "Default",     db_password);
        }
        protected void getConnectionString()
        {
            Interaction.GetSetting("Projectname", "Connection", "Default", "");
        }
    }
    }
