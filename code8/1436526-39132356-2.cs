        Dictionary<int, Flight> dictioneryFlight = new Dictionary<int, Flight>();
        do
        {
            Console.Write("Enter flight nummer (only numbers) :");
            // Always check user input, do not take for granted that this is an integer            
            if(Int32.TryParse(Console.ReadLine(), out FlNr))
            {
                if(FlNr != 0)
                {
                    // You cannot add two identical keys to the dictionary
                    if(dictioneryFlight.ContainsKey(FlNr))
                        Console.WriteLine("Fly number already inserted");
                    else
                    {
                        Console.Write("Enter destination :");
                        FlDest = Console.ReadLine();
                    
                        Flight f = new Flight() { FlightNr = FlNr, Destination = FlDest };
                        // Add it
                        dictioneryFlight.Add(FlNr, f);
                     }
                 }   
            }
            else
               // This is needed to continue the loop if the user don't type a 
               // number because when tryparse cannot convert to an integer it
               // sets the out parameter to 0.
               FlNr = -1;
        } while (FlNr != 0); 
