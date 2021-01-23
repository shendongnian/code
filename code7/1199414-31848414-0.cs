    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("France", "Paris");
        dictionary.Add("England", "London");
        dictionary.Add("Jordan", "Amman");
        var result = textbox1.Text;
        foreach (var entry in dictionary)
        {
            result.Replace(entry.Key, entry.Value);
        }
        textbox2.Text = result;
    }
