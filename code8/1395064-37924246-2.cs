    foreach (string ReponseRadioButton in ReponsesRadioButton)
                    {
                        foreach (RadioButton radioButtonActuel in reponseGroupBox[iterationQuestion].Controls.OfType<RadioButton>()) // Pour chaque RadioButton du reponseGroupBox associé à questionActuel
                        {
                                if (radioButtonActuel.Text == "En accord" && ReponseRadioButton == "En accord")
                                {
                                    radioButtonActuel.Checked = true;
                                }
    
                                if (radioButtonActuel.Text == "En desaccord" && ReponseRadioButton == "En desaccord")
                                {
                                    radioButtonActuel.Checked = true;
                                }
    
                                if (radioButtonActuel.Text == "Non applicable" && ReponseRadioButton == "Non applicable")
                                {
                                    radioButtonActuel.Checked = true;
                                }
                        }
                        iterationQuestion++;
                    }
