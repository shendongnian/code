    for(int i = 0; i < n; i++){
          for(int j = 0; j < n; j + 2){
            string input = Console.ReadLine();
            string[] split = input.Split(' ');
            int firstNumber = Int32.Parse(split[0]);
            int secondNumber = Int32.Parse(split[1]);
            matrix[i,j] = firstNumber ;
            matrix[i,(j+1)] = secondNumber ;
           }
       }
