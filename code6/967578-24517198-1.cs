<!-- -->
    var culture = CultureInfo.GetCultureInfo("sv-SE");
    var pattern = new MaskedTextProvider("X&&&&&&-X&&&&&&&", culture);
    int position;
    MaskedTextResultHint hint;
    if (!pattern.VerifyString(text, out position, out hint))
    {
        MessageBox.Show(string.Format("Error at {0}: {1}", position, hint));
    }
    else
    {
        MessageBox.Show("OK");
    }
