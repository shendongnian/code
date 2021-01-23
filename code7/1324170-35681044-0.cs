     public MainForm()
    {
        InitializeComponent();
    }
    Car myCar;
 
    private void getInput()
    {
        string year;
        string make;
        year = yearTextBox.Text;
        make = makeTextBox.Text;
        myCar = new Car(year, make);
        speedLabel.Text = myCar.Speed.ToString();
    }
    private void accelerateButton_Click(object sender, EventArgs e)
    {
        getInput();
        myCar.Accelerate(); 
    }
    private void brakeButton_Click(object sender, EventArgs e)
    {
        getInput();
        myCar.Brake(); 
    }
}
