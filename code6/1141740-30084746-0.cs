    int lastIndexRead = 0;
    public void Next()
    {
        if(i == Student.studentsList.Count) // do something - index is out of bounds of the array
        else
        {
           txtFirstName.Text = Student.studentsList[i].FirstName;
           i++;
       }
    }
