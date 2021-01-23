    public void Print(bool students = true)
    {
        if(students)
           Print(this.students.ToArray());
        else
           Print(staff.ToArray());
    }
