        int input = 3;
        int retVal = 0;
        int summation = input * input; //summation is equal to 9
        for (int i = 0; i <= input; i++)
        {
            retVal += i; 
            summation +=  i; /*this is basically saying add summation plus i tosummation (9 is assigned 9 + 0 so summation is still 9). Then, when i is 1, summation changes to 10. When i is 2, summation changes to 12, and when i is 3, summation is 15. What you should be doing is initialize summation to 0 and in the for loop, do this: summation +=  i * i (summation is assigned summation + (i * i)) Also, no need to start i from 0 (it is doing one extra loop for nothing). You should start i from 1. */
        }
        Console.WriteLine(retVal);
        Console.WriteLine(summation); //Another user already provided the solution. I just wanted to explain you your code.
