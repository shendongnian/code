    string data = "2:30, 3:00, 4:00, 5:00, 6:00, 7:00, 8:00, 9:00, 10:00, 11:00, 12:00, 1:00, 2:00, 3:00, 4:00, 5:00, 6:00, 7:00, 8:00, 9:00, 10:00, 11:00, 12:00, 1:00, 2:00";
    string[] parts = data.Split(',');
    
    DateTime lastInput = DateTime.MinValue;
    List<DateTime> dates = new List<DateTime>();
    string currentAMPM = "AM";
    foreach(string s in parts)
    {
        DateTime temp;
        
        if(DateTime.TryParse(s + " " + currentAMPM, out temp))
        {
            if(temp < lastInput)
            {
                currentAMPM = (currentAMPM == "AM" ? "PM" : "AM");
                DateTime.TryParse(s + " " + currentAMPM, out temp);
            }
            dates.Add(temp);
            lastInput = temp;
        
        }
    }
