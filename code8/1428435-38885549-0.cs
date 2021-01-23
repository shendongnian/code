    ConsoleColor color;
    if (!Enum.TryParse(session.LogicSettings.ErrorColor, out color))
    {
        // this is the fallback color in case an invalid value was entered.
        color = ConsoleColor.Red;
    }
    
    Console.ForegroundColor = color;
