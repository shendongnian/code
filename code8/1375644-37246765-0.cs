    decimal newCar;
    //send the uninitialized newCar variable to TryParse. If everything went ok, the variable will contain the equivalente decimal value.
    if(! Decimal.TryParse(vehicleTextBox.Text, out newCar)){
        //You can be almost certain that if the conversion failed it's because of the format
        MessageBox.Show("Invalid entry (Format Exception). \n" + "Please enter a valid decimal number.");
        KeyBoard.Focus(vehicleTextBox);
        vehicleTextBox.SelectAll();
    }
    //Validate the converted number was not negative
    if(newCar < 0){
        MessageBox.Show("Invalid entry (Negative Value). \n" + "Please enter a valid decimal number.");
        KeyBoard.Focus(vehicleTextBox);
        vehicleTextBox.SelectAll();
    }
    //At this point you have your newCar variable and it's valid.
}
