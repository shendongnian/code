    double prijs = 0;
    foreach (Artikel a in lbLidlKosten.Items)
    {
        prijs += a.Prijs;
    }
    label2.Text = Convert.ToString(prijis);
