    public partial class MainForm : Form
    {
    Car mycar;
    private void getInput()
        {
            string year;
            string make;
            int speed = 0;
    
    
    
            year = yearTextBox.Text;
            make = makeTextBox.Text;
    
            myCar = new Car(year, make);
            speedLabel.Text = myCar.Speed.ToString();
    
    
    
        }
    }
