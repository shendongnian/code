    int? a = (int?)getlev.ExecuteScalar();
     if (a != null)
     {
          if (a==0) {CVmax.IsValid = false;}
     }
     else
     {
          CVmax.IsValid = false
     }
