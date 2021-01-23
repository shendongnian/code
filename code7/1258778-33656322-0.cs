                string q;
                int retryCount = 1;
    
                Console.WriteLine("Welcome to the Ultimate quiz!");
                Console.WriteLine();
    
                start:
                const int numberOfQuestions = 5;
                for (int i = 1; i <= numberOfQuestions; i++) {
                    if (i > 1) {Console.WriteLine();}
                    switch (i) {
                        case 1:
                            Console.WriteLine("The JavaScript Language is not object oriented (True/False)");
                            break;
                        case 2:
                            Console.WriteLine("What is the age range to qualify for an apprenticeship in the uk? Please type in the following format xx-yy");
                            break;
                        case 3:
                            Console.WriteLine("Is HTML a programming language (Yes or No)");
                            break;
                        case 4:
                            Console.WriteLine("In JavaScript, What are the 2 charecters used to symbolise a single line comment?");
                            break;
                        case 5:
                            Console.WriteLine("500 < 600 && 700 < 600");
                            Console.WriteLine();
                            Console.WriteLine("Is the above statement true or false ?");
                            break;
                    }
    
                    Console.WriteLine();
                    q = Console.ReadLine();
                    q = q.ToUpper();
    
                    switch (i) {
                        case 1:
                            if (q == "TRUE") {
                                Console.WriteLine();
                                Console.WriteLine("Well Done, you may move on to the next question");
                            } else {  goto restart; }
                            break;
                        case 2:
                            if (q == "16-24") {
                                Console.WriteLine();
                                Console.WriteLine("Well Done, you may move on to the next question");
                            } else { goto restart; }
                            break;
                        case 3:
                            if (q == "NO") {
                                Console.WriteLine();
                                Console.WriteLine("Well Done, you may move on to the next question");
                            } else { goto restart; }
                            break;
                        case 4:
                            if (q == "//") {
                                Console.WriteLine();
                                Console.WriteLine("Well Done, you may move on to the next question");
                            } else { goto restart; }
                            break;
                        case 5:
                            if (q == "FALSE") {
                                Console.WriteLine();
                                goto end;
                            } else { goto restart; }
                            break;
                    }
                }
    
                restart:
                Console.WriteLine("Sorry you got the answer wrong, you have to start again");
                retryCount += 1;
                goto start;
    
    
                end:
                Console.WriteLine("Congratulations You have passed the quiz!");
                Console.WriteLine(String.Format("Well done!, you took {0} times to complete the quiz.", retryCount));
                Console.ReadKey();
  
