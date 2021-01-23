    //Second task
    int age;
    int rep;
    Console.WriteLine ("How old are you? ");
    age = Convert.ToInt32 (Console.ReadLine ());
    Console.WriteLine ("What is the your age divided by your first number submitted in the previous question? ");
    rep = Convert.ToInt32 (Console.ReadLine ());
    if (rep == age / num01 ) {
        Console.WriteLine ("That is correct. Proceed to the next question. ");
    } 
    else
    {
        Console.WriteLine ("That is incorrect. Start over. ");
    }
    Console.WriteLine ();
    //Third task
    string ans;
    Console.WriteLine ("Is your answer to the previous question an even or odd number? ");
    ans = Console.ReadLine ();
    //change 1
    if (rep % 2 == 0 && ans == "even")
    {
       Console.WriteLine ("That is correct. ");
    }
    //change2
    if (rep % 2 == 1 && ans == "odd") 
    {
        Console.WriteLine ("That is correct. ");
    }  
