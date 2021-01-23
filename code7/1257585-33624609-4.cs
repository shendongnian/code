    public void Add(Base c) 
    {
        if(c is Teacher)
            staff.Add((Teacher)c);
        else
            students.Add((Student)c);
    }
