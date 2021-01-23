    public partial class Form1 : Form
    {
        private Vehicle _selectedVehicle;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Create a vehicle for each radio button:
             Vehicle car = new Car {VehicleType = "Nissan Murano 2007", Vehiclecolor = "Black"Vehiclecolor = "Black"};
        
             radioButton1.Tag = car;
        
        }
        
        private void Selection_Changed(object sender, EventArgs e)
        {
          //Subscribe all radio button's Checked change to this event.
          _selectedVehicle = (sender as RadioButton).Tag
          
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        { 
          if(_selectedVehicle==null)
            {
              MessageBox.Show("Select vehicle type");
              return;
            }
            _selectedVehicle.DriveMe();
        }
        
        }
