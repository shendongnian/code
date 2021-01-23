    public partial class MainForm : XtraForm
    {
        private Dictionary<string, string> lastVisitedCustomers;
    
        public MainForm()
        {
            InitializeComponent();
            InitSkinGallery();
            UserLookAndFeel.Default.SkinName = Settings.Default["ApplicationSkinName"].ToString();
            lastVisitedCustomers = StringToDictionary(Settings.Default["LastVisitedCustomer"].ToString());
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            Settings.Default["LastVisitedCustomer"] = DictionaryToString(lastVisitedCustomers);
            Settings.Default.Save();
        }
        #region Dictionary management
        
        private string DictionaryToString(Dictionary<string, string> dic)
        {
            if (dic.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                string dicString = string.Empty;
                int i = 0;
                foreach (KeyValuePair<string, string> entry in dic)
                {
                    if (i == 0)
                    {
                        dicString = String.Format("{0} ## {1}", entry.Key, entry.Value);
                        i++;
                    }
                    else
                    {
                        dicString += String.Format(" -- {0} ## {1}", entry.Key, entry.Value);
                    }
                }
                return dicString;
            }
        }
        private Dictionary<string, string> StringToDictionary(string str)
        {
            Dictionary<string, string> dic = new Dictionary<string,string>();
            if (String.IsNullOrEmpty(str))
            {
                return dic;
            }
            else
            {
                string[] entries = Regex.Split(str, " -- ");
                
                foreach (string entry in entries)
                {
                    string[] kvp = Regex.Split(entry, " ## ");
                    dic.Add(kvp[0], kvp[1]);
                }
                return dic;
            }
        }
    }
        #endregion
