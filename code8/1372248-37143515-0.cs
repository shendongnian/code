    {
    
            double r;
            try{
            Console.WriteLine("Please enter the radius: ");
            }
            catch(Exception e){}
            try{
               r = Convert.ToDouble(Console.ReadLine());
            }
            catch(Exception e){}
            double areaCircle = pi * (r * r);
            Console.WriteLine("Radius: {0}, Area: {1}", r, areaCircle);
            Console.ReadLine();
    
        }
