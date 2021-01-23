         int[] numbers = new int[5];
         int i = 0;
         while (i < 5) {
            Console.WriteLine ("Enter a number: ");
            string c = Console.ReadLine ();
            int value;
            if (int.TryParse (c, out value)) {
               numbers[i] = value;
               i++;
            } else {
               Console.WriteLine ("You did not enter a number\n");
            }
         }
         for (i = 0; i < numbers.Length; i++) {
            Console.Write (numbers[i] + " ");
         }
