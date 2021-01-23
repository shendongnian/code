    public Berenlijst getdetails()
    {
        if (RDB_pluche.Enabled == true)
        {
            return new Pluche_Beer(TXTNaam_pluche.Text, open_foto.FileName, "(Wasprogramma: " + TXT_wasprogramma.ToString() + " Graden Celsius");
        }
            return new Elektronische_Beer(TXTNaam_elekro.Text, open_foto.FileName, "aantal Batterijen: " + CMBOBatterijen.ToString());
    }
