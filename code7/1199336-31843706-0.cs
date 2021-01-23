    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("France", "Paris");
        dictionary.Add("England", "London");
        dictionary.Add("Jordan", "Amman");
        textbox2.Text = "";
        if (textbox1.Text.Contains("France"))
        {
            string value = dictionary["France"];
            textbox2.Text += value;
        }
        if (textbox1.Text.Contains("England"))
        {
            string value = dictionary["England"];
            textbox2.Text += value;
        }
        if (textbox1.Text.Contains("Jordan"))
        {
            string value = dictionary["Jordan"];
            textbox2.Text += value;
        }
    }
