    foreach (var registration in list)
    {
      Console.WriteLine(
             ((Type)registration.GetType().GetProperty(
                    "Implementation"
             ).GetGetMethod().Invoke(
                    registration,new object[] { })
             ).FullName);
    }
