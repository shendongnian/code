    //tells user if they overspent, underspent, or broke even
    //Budget 1
    if (moneyBudget[0] < actNum[0])
    {
        Console.WriteLine("You overspent by $" + Math.Abs(moneyBudget[0] - actNum[0]) + " this week.");
    }
    else if (moneyBudget[0] > actNum[0])
    {
        Console.WriteLine("You underspent by $" + Math.Abs(moneyBudget[0] - actNum[0]) + " this week.");
    }
    else
    {
        Console.WriteLine("You broke even this week.");
    }
