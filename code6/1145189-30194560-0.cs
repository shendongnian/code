    public class Settings
    {
        int intsetting { get; set; } /*= 0;*/ // commented only allowed in C# 6+
        string strsetting { get; set; } /*= "";*/
        public int IntSetting { get { return intsetting; } set { intsetting = value; } }
        public string StrSetting { get { return strsetting; } set { strsetting = value; } }
        static Settings()
        {
            IntSetting = 5;
            StrSetting = "Test str";
        }
    }
