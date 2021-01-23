    public static class IconInfo
    {
        public static string FileName(this Icon icon)
        {
            switch (icon)
            {
                case Icon.Box: return "/Noru;Component/NoruBox/Media/Box_512.png";
                case Icon.Person: return "/Noru;Component/NoruBox/Media/Person_512.png";
                default: return "";
            }
        }
    }
    public enum Icon
    {
        Box = 0,
        Person = 1,
    }
