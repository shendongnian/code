    private void bVergleich_Click(object sender, RoutedEventArgs e)
    {
        if (listBox.Items.Count <= 0)
        {
            MessageBox.Show("Bitte erst Einträge hinzufügen.");
        }
        else
        {
            List<decimal> tmpListe = new List<decimal>();
            int anzahl = listBox.Items.Count;
            for (int i = 0; i < anzahl; i++)
            {
                string str = listBox.Items[i].ToString();
                // collect all the second double values
                tmpListe.Add(decimal.Parse(str.Split(' ').Last(), NumberStyles.Currency, CultureInfo.CurrentCulture));
            }
            // get the minimal value and its index
            decimal minValue = tmpListe.Min();
            int index = tmpListe.IndexOf(tmpListe.Min());
            // use the index to get the name
            string str2 = listBox.Items[index].ToString();
            string vName = str.Substring(0, str2.IndexOf(" ") + 1);
            // write down your comparison
            lVergleich.Content = vName + " " + minValue + "€";
        }
    }
