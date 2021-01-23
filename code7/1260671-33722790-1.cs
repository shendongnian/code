    private void button1_Click(object sender, EventArgs e)
    {
        string airportName;
        double celsiusTemperature;
        double elevation;
        // Get data from controls and do syntactic checks
        bool ok = true;
        airportName = txtAirport.Text;
        ok = Double.TryParse(txtTemperature.Text, out celsiusTemperature);
        if (!ok)
        {
            // Error
            MessageBox.Show("The value you entered for temperature is not a number!", "Error");
        }
        ok = Double.TryParse(txtElevation.Text, out elevation);
        if (!ok)
        {
            // Error
            MessageBox.Show("The value you entered for elevation is not a number!", "Error");
        }
        if (ok)
        {
            // Create the instance of the data class and do semantic checks
            Airport myAirport = new Airport(airportName, celsiusTemperature, elevation);
            string errorMessage;
            if (!myAirport.IsValid(out errorMessage))
            {
                // Error
                MessageBox.Show(errorMessage + " Please reenter the information", "Error");
            }
            else
            {
                // Ok, data is valid. Continue normal work...
                MessageBox.Show("The airport name is: " + myAirport.AirportName + Environment.NewLine +
                                "The Celsius temperature is: " + myAirport.CelsiusTemperature + Environment.NewLine +
                                "The Fahrenheit temperature is: " + myAirport.TemperatureInFahrenheit + Environment.NewLine +
                                "The elevation is: " + myAirport.Elevation);
            }
        }
