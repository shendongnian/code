    public static List<Button> getButtons()
    {
        for ( int i=0; i<5; i++)
        {
            Button _button = new Button
            {
                Name = "navBtn" + i.ToString(),
                Width = 50,
                Height = 50,
                Content = "\uE173",
                Background = new SolidColorBrush(Colors.Gray)
            };
            _button.Click += _button_Click;
            menuButtons.Add(_button);
        }
        return menuButtons;
    }
      
