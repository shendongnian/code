    class SettingsClass
    {
        enum Idioms
        {
            English, French, Spanish, German
        }
        
        public Array UpdateComboBoxIdioma()
        {
            return Enum.GetValues(typeof(Idioms));
        }
    }
