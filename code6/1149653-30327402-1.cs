     public partial class frm_Settings : Form
        {
            MainWindow main;
    
            public frm_Settings(MainWindow mainWin)
            {
                InitializeComponent();
                main = mainWin;
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (opt_amharic.Checked == true)
                {
                    main.langPref_Amharic();
                }
                if (opt_english.Checked == true)
                {
                    main.langPref_English();
                }
            }
        }
    }
