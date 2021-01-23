    }
    else
    {
        int indexGenerator = numberGenerator.Next(1, 4);
        int answer1 = finalUserInput - theCorrectAnswer;
        switch (indexGenerator)
        {
            case 1:
                Console.WriteLine("You are off by" + answer1);
                break; // missing break
            case 2:
                Console.WriteLine("So close. Maybe if you add or subtract " + answer1 + "?");
                break; // missing break
