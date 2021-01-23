    public SolidColorBrush GetColor { 
        get {
            Color GetIt;
            switch(ReminderColor) {
                case("1"):
                     GetIt = Color.FromArgb(255, 135, 136, 0);
                case("2"):
                     GetIt = Color.FromArgb(177, 237, 237, 0);
                case("3"):
                     GetIt = Color.FromArgb(214, 243, 153, 0);
                case("4"):
                     GetIt = Color.FromArgb(214, 243, 153, 0);
            }
            SolidColorBrush TestBrush = new SolidColorBrush(Getit);
            return TestBrush;
       }
    }    
