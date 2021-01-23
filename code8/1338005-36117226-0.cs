     Console.WriteLine("Please enter any nth number of the Fibonacci series.");
        string user_num = Console.ReadLine();
        int userNumber = int.Parse(user_num);
        int[] FibNum = new int[userNumber];
        int firstNum = 1;
        Console.Write("{0},", firstNum);
        int secondNum = 1;
        Console.Write("{0},", secondNum);
        int sumNum = 0;
        while (sumNum <= userNumber)
        {
            sumNum = (firstNum + secondNum);
            if(sumNum>=userNumber)   //check to filter less values
            Console.Write("{0}, ", sumNum);
            firstNum = secondNum;
            secondNum = sumNum;               
        }
        Console.ReadLine(); 
