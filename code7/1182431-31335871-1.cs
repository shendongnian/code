    TimeSpan SumAll(params TextBox[] lapTimeTextBoxes)
    {
        TimeSpan result = new TimeSpan();
        TimeSpan temp = new TimeSpan();
        for(int i = 1; i < lapTimeTextBoxes.Length; i++)
        {
           if(!TimeSpan.TryParse(lap6TimeTextBox.Text, Temp)) continue;
           result += temp;
        }
        return result;            
    }
