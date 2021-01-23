            string selectedUnit = selectedinitialunit.SelectedItem.ToString();
            string convertedUnit = selectedconvertedunit.SelectedItem.ToString();
            double valueToConvert = double.Parse(initialvalue.Text);
            if (selectedUnit.Equals(convertedUnit))
            {
                MessageBox.Show("Please select a different selectedconvertedunit");
            }
            else
            {
                switch (selectedUnit)
                {
                    case "INCHES":
                        switch (convertedUnit)
                        {
                            case "FEET":
                                convertedvaluelabel.Text = (valueToConvert / 12.0).ToString();
                                break;
                            case "YARDS":
                                convertedvaluelabel.Text = (valueToConvert / 36.0).ToString();
                                break;
                        }
                        break;
                }
            }
