        /*------------------------------QUESTION 1-------------------------------- */
        while (true)
        {
            ++count;
            Console.WriteLine("The JavaScript Language is not object oriented (True/False)");
            //... other questions as they were....
            // with one small change e.g.
            if (q1 == "TRUE")
            {
                Console.WriteLine();
                Console.WriteLine("Well Done, you may move on to the next question");
            }
           else
            {
                Console.WriteLine("Sorry you got the answer wrong, you have to start again");
                continue; // <-----------instead of goto start;
            }
            //... other questions as they were....
            //with one small change
           if (q5 == "FALSE")
           {
                Console.WriteLine();
                Console.WriteLine("Well Done, you may move on to the next question");
                Console.WriteLine();
                Console.WriteLine("Congratulations You have passed the quiz!");
                break; //<--------- if they get the final question right,
                       // break out of the while loop
           }
    
        } //<- end of while loop
        //Output message you suggested
        Console.WriteLine("You took {0} attempts", count);
