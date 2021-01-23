    static class ButtonFactory
    {
        public static Button CreateButton(ButtonType buttonType)
        {
            switch (buttonType)
            {
                case ButtonType.OK:
                    return CreateButton("OKBtn", "OK");
    
                // process other button types
            }
        }
        private static Button CreateButton(string name, string text)
        {
            var button = new Button();
            button.Name = name;
            button.Text = text;
            return button;
        }
    }
