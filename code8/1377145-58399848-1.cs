    using System;
    using System.Linq;
    using System.Globalization;
    using System.Windows.Forms;
    ...
    public static void Switch_keyboard(string lang)
    {
        CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(lang);
        InputLanguage inputLanguage = InputLanguage.FromCulture(cultureInfo);
        InputLanguage.CurrentInputLanguage = inputLanguage;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var list = InputLanguage.InstalledInputLanguages.Cast<InputLanguage>().Select(c => c.Culture.Name).ToList(); 
        Switch_keyboard(list[0]); // "ru-RU" or "ru-BY" ...
    }
