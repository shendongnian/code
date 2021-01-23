    private void ApplyButton_Click(object sender, EventArgs e)
    {
        var cultureInfo = new System.Globalization.CultureInfo(cboCultureInfo.SelectedItem.ToString());
        ResourceLoader.ChangeLanguage(this, cultureInfo);
    }
