    object BatQuantity= pi[3].GetValue(SystemInformation.PowerStatus, null);
    
    //convert the value I get from PowerStatus class to %
    float num = (Single.Parse(CantdeBat.ToString())) * 100;
    
    //shows battery % and if battery is full says it's full if not it says it's low
    string batteryStatus = num.ToString() + "%";
    if (num == 100)
    {
        batteryStatus = "-Full Battery-";
    }
    else if (num <= 25)
    {			
        batteryStatust = "-Low Battery-";
    }            
    label4.Text = batteryStatust;
