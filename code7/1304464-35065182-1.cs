    public class MyTheme : Theme
    {
        public MyTheme()
        {
            DictionaryThemes(typeof(MyTheme));
        }
        //Slate
        public override Color TitleColour { get; } = Color.FromHex("#00ff00");
    }
