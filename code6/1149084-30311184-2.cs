    public class ClassConfigData
    {
        public logicData[] logic = new logicData[100];
        public string fileLocName;
        public ClassConfigData()
        {
            for (int i = 0; i < logic.Length; i++)
            {
                logic[i] = new logicData();
            }
        }
    }
    public class logicData
    {
        public colorProfileSettings[] colors = new colorProfileSettings[2];
        public int configBtnLedTest = 0;
        public int configBtnDimPlus = 0;
        public int configBtnDimMin = 0;
        public int configBtnCleaning = 0;
        public int configBtnDayNightToggle = 0;
        public int groupBg = 0;
        public int groupLedTest = 0;
        public int groupDimming = 10;
        public logicData()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = new colorProfileSettings();
            }
        }
    }
