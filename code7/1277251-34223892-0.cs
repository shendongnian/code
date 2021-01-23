    private void Gewicht_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       float a;
       float b;
       if (float.TryParse(Körpergröße.SelectedItem.ToString(), out a) && float.TryParse
    (Gewicht.SelectedItem.ToString(), out b))
       {
          fillTextBox(a, b);
          string str = "";
       }
    }
