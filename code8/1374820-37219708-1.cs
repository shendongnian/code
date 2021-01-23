    int i = 0;
    while(i < number)
    {
           int die = random.Next(1, sides); 
           Console.WriteLine("You Rolled {0}", die.ToString());
           total += die;
           i++
    }
