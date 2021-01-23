    public class PageDataModel
    {
        public bool setting1 { get; set; }
        public bool setting2 { get; set; }
        public bool setting3 { get; set; }
    
        public bool SelectedSetting
        {
            get
            {
                if (setting1) return "setting1";
                if (setting2) return "setting2";
                if (setting3) return "setting3";
                return null; // or you can set a default here
            }
            set
            {
                switch (value)
                {
                    case "setting1":
                        setting1 = true;
                        break;
                    case "setting2":
                        setting2 = true;
                        break;
                    case "setting3":
                        setting3 = true;
                        break;
                }
            }
        }
    }
