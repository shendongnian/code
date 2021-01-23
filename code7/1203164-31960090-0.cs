    else if (Divide > RESULT_MAXVALUE) //RESULT_MAXVALUE is an const public decimal = 250
            {
                if (RESULT_MAXVALUE == 250)
                    Console.WriteLine("Everything's fine");
                else 
                    throw new NotSupportedException()
            }
