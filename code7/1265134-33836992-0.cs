    private void button2_Click(object sender, EventArgs e)
    {
        vehicle v = null;
        if (radioButton1.Checked == true)
        {
            v = new car();
            v.Vehiclecolor = "Black";
        }
        else if (radioButton2.Checked == true)
        {
            v = new truck();
            v.Vehiclecolor = "White";
        }
        else if (radioButton3.Checked == true)
        {
            v = new bike();
            v.Vehiclecolor = "Red";
        }
        else if (radioButton4.Checked == true)
        {
            v = new train();
            v.Vehiclecolor = "Blue";
        }               
        else
        {
            v = new vehicle();
            v.Vehiclecolor = "Please Select the Vehicle Type";               
        }
        v.color();
    }
