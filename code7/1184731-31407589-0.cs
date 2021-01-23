<a href="https://msdn.microsoft.com/en-us/library/sbkb459w.aspx">this</a> = is the assignment operator in C#<br />
<a href="https://msdn.microsoft.com/en-us/library/53k8ybth.aspx">this</a> == is a comparison operator in C#<br />
Start:
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Question 1: Test? type yes or no: ");
        String answer1 = Console.ReadLine();
        
        if (answer1 == "yes")
        {
            Console.WriteLine();
            Console.WriteLine("Question 2: Test? type Yes or no");
        }
        else if (answer1 == "no")
        {
            Console.WriteLine();
            Console.WriteLine("Wrong, restarting program");
            goto Start;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Error");
            goto Start;
        }</code></pre>
