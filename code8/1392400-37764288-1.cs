    ManageMe manage = new ManageMe();
    try 
    {
         manage.Add(4,8);
         Console.WriteLine("using statement executed");
    }
    finally 
    {
        manage.Dispose();
    }
