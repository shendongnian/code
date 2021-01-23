	private static int x;
	private static IEnumerator Loop0()
	{
	  for(;;)
	  {
		x++;
		yield return null;
		x++;
		yield return null;
		x++;
		yield return null;
		x++;
		yield return null;
	  }
	}
	private static IEnumerator Loop1()
	{
	  for(;;)
	  {
		Console.WriteLine("X=" + x);
		yield return null;
		Console.WriteLine("X=" + x);
		yield return null;
		Console.WriteLine("X=" + x);
		yield return null;
		Console.WriteLine("X=" + x);
		yield return null;
	  }
	}
	private static void Driver()
	{
	  // Again, I'm going to do a simple time-based mechanism here:
	  var stateMachines = new IEnumerator[] { Loop0(), Loop1() };
	  for (int i = 0;; i = (i + 1) % stateMachines.Length)
	  {
		var cur = stateMachines [i];
		DateTime until = DateTime.UtcNow.AddMilliseconds (100);
		do
		{
		  cur.MoveNext ();
		} while (DateTime.UtcNow < until);
	  }
	}
