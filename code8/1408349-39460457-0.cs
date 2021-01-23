    public class MyValueFormatter : Java.Lang.Object, IValueFormatter
    {
        public string GetFormattedValue(float value, Entry entry, int dataSetIndex, ViewPortHandler viewPortHandler)
        {
            return value.ToString("F0");
        }
    }
