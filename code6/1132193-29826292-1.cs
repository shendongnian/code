    ProgressBar progressBar =  splash.Controls["myProgressBar"];
         
    foreach (string line in lines)
                        {
                            foreach (ComboBox comboBox in controls.OfType<ComboBox>())
                            {
                                if (line.StartsWith("ComboBox"))
                                {
        
                                    comboBoxesNames = line.Substring(14);
                                }
                                else
                                {
                                    if (line.StartsWith("Classes"))
                                    {
        
                                        if (comboBox.Name == comboBoxesNames)
                                        {
                                            comboBox.Items.Add(line.Substring(14));
        
                                        }
                                    }
                                }
                                progressBar.PerformStep();
                            }
                        }
