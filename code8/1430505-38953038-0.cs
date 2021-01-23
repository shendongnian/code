    if (Properties.Settings.Default["CompteDefautFactureF"].ToString() != "")
                    {
                        foreach (ClsCompte l_Account in this.cbo_Compte_FF.Items)
                        {
                            if (l_Account.ID.ToString().Equals( Properties.Settings.Default["CompteDefautFactureF"].ToString()))
                            {
                                this.cbo_Compte_FF.SelectedItem = l_Account;
                                break;
                            }
                        }
                    }
                    else
                    {
                        this.cbo_Compte_FF.SelectedItem = null;
                    }
