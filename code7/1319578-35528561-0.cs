    [HttpPost]
    public void SnimiStudenta(Student s)
    {
        Connection.dc.Students.Add(s);
        Connection.dc.SaveChanges();
    }
