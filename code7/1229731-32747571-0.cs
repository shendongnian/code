    public static int CalculateAge(string birthdate, string examDate)
    {
      DateTime dob = DateTime.Parse(birthdate);
      DateTime ed = DateTime.Parse(examDate);
      
      int age = ed.Year - dob.Year;
      if (ed.Month < dob.Month)                         
      {
        age--;
      }
      else if (ed.Month == dob.Month &&
        ed.Day < dob.Day)
      {
        age--;
      }
    
      return age;
    }
