            int enteredValue;
            int? smallest = null, secondSmallest = null;
            for (int i = 0; i < 10; i = i + 1)
            {
                Console.WriteLine("Vpiši " + i+1 + " število: ");
                enteredValue = Convert.ToInt32(Console.ReadLine());
                if (smallest==null || enteredValue<smallest) {
                      secondSmallest=smallest;
                      smallest = enteredValue;
                } else if (enteredValue!=smallest && enteredValue<secondSmallest) {
                      secondSmallest= enteredValue;
                }
            }
