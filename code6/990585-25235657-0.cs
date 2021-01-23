     private string[] Logo_menu_array = { "Assets/star-6-48.ico", "/Assets/note-48.ico", "/Assets/medal-48.ico", "/Assets/joystick-48.ico" };
        private string[] Text_menu_array={"Phổ biến trên YouTuBe","Âm nhạc","Thể thao","Trò chơi"};
      
       
        public class listboxitem
        {
            public string textmenu { get; set; }
            public string logomenu { get; set; }
        }
    public List<listboxitem> Load_Menu()
        {
            List<listboxitem> text = new List<listboxitem>();
            for (int i = 0; i < Math.Min(Logo_menu_array.Length, Text_menu_array.Length); i++)
            {
                var l = new listboxitem();
                l.logomenu = Logo_menu_array[i];
                l.textmenu = Text_menu_array[i];
                text.Add(l);
            }
            return text;
        }
    public MainPage()
        {
            this.InitializeComponent();
            //get menu
             List<listboxitem> menu_list = Load_Menu();
             lst_menu.ItemsSource = menu_list;
            
            
        }
