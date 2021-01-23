    // Form1. The window form
    private void button2_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Hours().ToString());
    }
    // My ClassName with method Hours()
    public decimal Hours()
    {
        var citiesDistance = new Dictionary<string, int> 
        { 
            {"Place1",10},
            {"Place2",20},
            {"Place3",30},
        };
        var cities = "Place1";
        var length = citiesDistance[cities];
        var speed = 100;
        var hours = length / speed;
        return hours;
    }
