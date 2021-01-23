    public static void Main()
    {
       try {
           SendMail();
      }
      catch(Exception e) {
         if (e.InnerException != null)
            Console.WriteLine("Inner exception: {0}", e.InnerException);
      }
   }
