    DateTime? utcNow = null;
    // ...
    if(variable > 1 && !utcNow.HasValue){
        utcNow = DateTime.UtcNow;
        Console.Writeline(utcNow.Value.Ticks);
    }
