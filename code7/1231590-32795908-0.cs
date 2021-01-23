    DateTime t1 = DateTime.Today.AddHours(8);
		
    for(int i = 0; i < 5; i++) {
        Console.WriteLine(t1.AddMinutes(15 * i).ToString("HH:mm"));	
    }
