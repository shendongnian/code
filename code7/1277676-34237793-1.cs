    private void CalculateValues()
    {
            int value1, value2;
            if (Gewicht.SelectedItem.ToString() != "Bitte auswählen..." && Körpergröße.SelectedItem.ToString() != "Bitte auswählen...")
            {
                string a = Körpergröße.SelectedItem.ToString();
                string b = Gewicht.SelectedItem.ToString();
    
                value1 = Int32.Parse(a);
                value2 = Int32.Parse(b);
                fillTextBox(value1, value2);
            }
    }
    
    
        private void Gewicht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    if(Gewicht.SelectedIndex > -1 && Körpergröße.SelectedIndex > -1)
    {
    CalculateValues();
    }
    }
    
        private void Körpergröße_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    if(Körpergröße.SelectedIndex > -1 && Gewicht.SelectedIndex > -1 )
    {
    CalculateValues();
    }
    }
