     static void Main(string[] args)
        {
            try
            {
                Service service = new Service();
                service.GetService(-8);
                service.GetType().GetCustomAttributes(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
           
        }
