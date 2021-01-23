    if (opt_amharic.Checked == true)
    {
        Dispatcher.Invoke(() => { main.langPref_Amharic(); });
    }
    if (opt_english.Checked == true)
    {
        Dispatcher.Invoke(() => { main.langPref_English(); });
    }
