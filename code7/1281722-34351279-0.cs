     // assuming by the name this is only for the listBoxKunder
     // and every time the selected index changes, this method is invoked
     private void listBoxKunder_SelectedIndexChanged(object sender, EventArgs e)
    {
        aktuellKund = (Kund)listBoxKunder.SelectedItem;
        // here you are changing the data source of the list box and this should/may cause 
        // the selected index to change! This in turn calls this method again
        // To fix this, to not modify the DataSource property in respnse to a SelectedIndexChanged event 
        listBoxKunder.DataSource = KundLista;
        listBoxKonto.Items.Clear();
        foreach (Konto item in aktuellKund.kontolista)
        {
            listBoxKonto.Items.Add(item);
        }
        if(aktuellKund!= null)
        {
            textBoxFörNamn.Text = aktuellKund.Förnamn;
            textBoxEfternamn.Text = aktuellKund.Efternamn;
            textBoxPersonnummer.Text = aktuellKund.Personnummer;
            textBoxGatuAdress.Text = aktuellKund.GatuAdress;
            textBoxTelefon.Text = aktuellKund.Telefon;
            textBoxMobil.Text = aktuellKund.Mobil;
        }
     }
