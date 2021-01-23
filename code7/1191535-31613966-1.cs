    var abc = new LetterList("abcdefghijklmnopqrstuvwxyz");
    var answer = new LetterList("myanswer");
    Console.WriteLine("This my question. Why? write your answer please");
    char x = Console.ReadLine()[0];
    if (answer.FindLetter(x))
    {
        Console.WriteLine("you are right!");
    }
    else
    {
        Console.WriteLine("fail");
    }
    abc.FindLetter(x);
    Console.WriteLine("not chosen abc:{0} answer:{1}", abc.NotChosen(), answer.NotChosen());
