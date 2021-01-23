        So,Let's say your a.txt contain thefollowing cases:
           case 1:"Hello World"
           while (test.ReadLine() != null)
            {
                Console.WriteLine("HI" + test.ReadLine());
            }
			
	    since,we have only one line ,so next line is null and finally it reached the EOD.
	  
        case 2:"Hello World"
       "I am a coder"
           while (test.ReadLine() != null)
            {
                Console.WriteLine("HI" + test.ReadLine());
            }
			
	  since,we have  two line so ,next line is "I am a coder".
	  It returns:Hi I am a coder.
	  	  
    And in the below code we are reading and assing to stirng  vairbale
    StreamReader test1 = new StreamReader(@"D:\a.txt");
            string line = "";
            while ((line = test1.ReadLine()) != null)
            {
                Console.WriteLine(line);
            } 
			
			so we ,see the result.
