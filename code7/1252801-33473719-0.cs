    private void getDate_1()
    {
        var flag = true;
        while (flag)
        {
           Console.WriteLine("Enter today's date (mm/dd/yyyy): ");
           String mydate = Console.ReadLine();
           try 
           {
               date1 = Convert.ToDateTime(mydate);
               dateflag = true;
               flag = false;
           }
           catch (Exception e)
           {
               Console.WriteLine("Wrong format, try again: ");
           }
        }
     }
