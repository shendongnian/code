        //First, move the definition of a generic vehicle to a field.
        Vehicle v = null;
        private void button1_Click_1(object sender, EventArgs e)
        {                
            if (radioButton1.Checked == true)
            {
                v = new car();
                v.VehicleType = "Nissan Murano 2007";
            }
            else if (radioButton2.Checked == true)
            {
                v = new truck();
                v.VehicleType = "Dodge Truck";
            }
            else if (radioButton3.Checked == true)
            {
                v = new bike();
                v.VehicleType = "Hardley Davidson Bike";
            }
            else if (radioButton4.Checked == true)
            {
                v = new train();
                v.VehicleType = "Train";
            }
            else
            {
                v = new vehicle();
                v.VehicleType = "Please Select the Vehicle Type";
            }          
            v.DriveMe();    //<--- See that it is outside, called once?
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (v == null)
            {
               MessageBox.Show("Please select a vehicle first.");
               return;
            }
            if (radioButton1.Checked == true)
            {
                v.Vehiclecolor = "Black";
            }
            else if (radioButton2.Checked == true)
            {
                v.Vehiclecolor = "White";
            }
            else if (radioButton3.Checked == true)
            {
                v.Vehiclecolor = "Red";
            }
            else if (radioButton4.Checked == true)
            {
                v.Vehiclecolor = "Blue";
            } 
            v.color();    //<-- Also only called once
        }
