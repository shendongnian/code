                double montant = -1;
    
                if (!double.TryParse(_controle.Text, out montant))
                    {
                        Declanche_Erreur = true;
                        _controle.BackColor = System.Drawing.Color.White;
                        return;
                    }
                    else
                    {
                        Declanche_Erreur = false;
                        _controle.BackColor = System.Drawing.Color.White;
                    }
