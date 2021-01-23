    int returnCode = db.SaveChanges();
    if(returnCode == 1 )
    {
       Console.WriteLine("Success");
    }
    else
    {
      Console.WriteLine("Something gone wrong");
    }
