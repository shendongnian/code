    drCheck = bal.Check(bel);
    if (drCheck.Read())
    {
         do
         {
            // read each record
         }
         while(drCheck.Read());
    }
    else
    {
        drCheck.Close();
       // I'm out
    }
    drCheck.Close();
