    Task.Factory.StartNew(
	() =>
	{
		for (int i = 0; i < 10; ++i)
			PrintNumber(i);
	});
    Task.Factory.StartNew(
	() =>
	{
		for (int i = 10; i > 0; --i)
			Beep();
	});
