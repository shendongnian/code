    foreach (var key in list)
    {
       // ...
       var s = new MyObject();  // create new object
       s.NRIC = nric;
       s.DOB = Convert.ToDateTime(dob);
       arr.Add(s);
    }
