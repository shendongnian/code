    public partial class MainWindow : Form
            {
                public MainWindow()
                {
                    InitializeComponent();
                }
        
        
                public void langPref_Amharic()
                {
                    main_amharic_pannel.Visible = true;
                    main_english_pannel.Visible = false;
                    home_amharic_title.Visible = true;
                    home_eng_title.Visible = false;
                }
                public void langPref_English()
                {
                    main_amharic_pannel.Visible = false;
                    main_english_pannel.Visible = true;
                    home_amharic_title.Visible = false;
                    home_eng_title.Visible = true;
                }
     
                public void OpenSettingsForm()
                {
                    frm_Settings settings = new frm_Settings(this);
                    settings.Show();
                }
        }
