    DateTime start =  (DateTime)datePreviDate.Value;
    DateTime end = (DateTime)datecurrentTime.Value;
    var timespan = end - start
    var totalTime = PREVTIME + CURRENTTIME;
    if(timespan.TotalDays > 2 && totalTime < 24){
       MessageBox.Show("You Cannot Change The Date");
       //Continue Code Here
    } else {
       MessageBox.Show("Your Appointment Has Been Changed");
       //Continue Code Here
    }
