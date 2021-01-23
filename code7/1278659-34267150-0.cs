    // Somewhere else in your code, create a dictionary with your day1-day8 objects
    var days = new Dictionary<int, Day>()
    days[1] = day1;
    ...
    days[8] = day8;
    //Simplfiy your method
    private void btnCandlesLight_Click(object sender, EventArgs e)
    {
    	try
    	{
        	var dayIndex = Convert.ToInt32(textBox1.Text);
        	if(dayIndex > 0 && dayIndex <= 8)
        	{
        		days[dayIndex].Start(); //Get the corresponding day via its Key
                LightUpCandles(dayIndex); //pass the key as a parameter
        	}
        	else
        	{
        		MessageBox.Show("Enter new day");
        	}
       	}
       	catch(InvalidCastException exception)
       	{
       		//Whatever you do when the textbox cannot be parsed
       	}
    }
