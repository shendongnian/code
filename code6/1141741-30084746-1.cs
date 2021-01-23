    int lastIndexRead = 0;
    public void Next()
    {
        if(lastIndexRead == Student.studentsList.Count) // do something - index is out of bounds of the array
        else
        {
           txtFirstName.Text = Student.studentsList[lastIndexRead].FirstName;
           lastIndexRead++;
       }
    }
