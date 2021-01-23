	var res = String.Join(", ", 
		Enumerable.Range(1, 7)
		.Select(n => 
		{
			int coin1 = RandomFlip(); //1 head 2 tails
			int coin2 = RandomFlip();
		
			return new { coin1, coin2 };
		})
		.Where(c => c.coin1 == c.coin2)
		.Select(c => c.coin1)
	);
    Console.Write(res);
