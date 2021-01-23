    using System;
    using System.Globalization;
    ...
    public static void Switch_keyboard(string lang)
    {
        CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(lang);
        InputLanguage inputLanguage = InputLanguage.FromCulture(cultureInfo);
        InputLanguage.CurrentInputLanguage = inputLanguage;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Switch_keyboard("en-US"); // "ru-RU" or "ru-BY" ...
    }
