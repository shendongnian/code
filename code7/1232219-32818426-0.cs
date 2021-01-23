    protected void AddButton_Click(object sender, EventArgs e)
    { 
        string colorAdded = "";
        switch(TextBox1.Text) { 
            case "red":
                colorAdded = System.Drawing.Color.Red;
                break;
            case "blue":
                colorAdded = System.Drawing.Color.Blue;
                break;
            case "green":
                colorAdded = System.Drawing.Color.Green;
                break;
            default:
                colorAdded = //Insert your default color here;
                break;
        }
    
        ResultLabel.Text += colorAdded + "<br/>";
    }
