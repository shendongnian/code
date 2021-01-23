    TimeSpan SumAll(params TextBox[] lapTimeTextBoxes)
    {
        TimeSpan result = default(TimeSpan);
        for(int i = 1; i < lapTimeTextBoxes.Length; i++)
           if(lapTimeTextBoxes[i] != null) result += TimeSpan.Parse(lap6TimeTextBox.Text);
        return result;            
    }
