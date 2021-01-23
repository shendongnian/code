    private void panel_Click(object sender, EventArgs e)
        {
            var p = (Panel)sender;
            if (EtapaInicialWasClicked)
            {
                p .BackgroundImage = Symbols.EtapaInicialbm;
                EtapaInicialWasClicked = false;
            }
        }
