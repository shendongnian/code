            if (y > 0)
            {
                e.HasMorePages = line != invoiceList.Count();
                Console.WriteLine("4th " + line);
                break;   
            }  
        } while (line < invoiceList.Count());
        Console.WriteLine("6th " + line);
       line = 0;
    }
