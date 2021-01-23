    string dateString = String.Format("{0} {1}:{2}:00", DateField.Text, TimeSelector1.Hour, TimeSelector1.Minute);
    DateTime selectedDateTime = new DateTime();
    if (DateTime.TryParse(dateString, out selectedDateTime))
    {
        if (selectedDateTime > DateTime.Now.AddHours(24))
        {
            // code
        }
    }
