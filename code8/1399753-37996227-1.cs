    switch (methodNumber)
    {
        case "1":
            Console.WriteLine("Please enter a valid order item number: ");
            string num = Console.ReadLine();
            List<TruckType> type = _service.GetVisionTruckType(num);
            foreach (var item in type )
            {   // this will only work if you override the ToString() 
                // method in the class TruckType 
                Console.WriteLine(item.ToString());
            }
            break;
    }
