	Console.WriteLine("\nEnter the cards you would like to remove as such: 1,2");
	string HandHolder = Console.ReadLine();
	string[] splitHandHolder = HandHolder.Split(',');
	int[] splitHandHolderint = Array.ConvertAll(splitHandHolder, int.Parse);
	var updated = playerHand.Where((x, n) => !splitHandHolderint.Contains(n + 1)).ToArray();
	playerHand = updated.Concat(deck.Take(5 - updated.Length)).ToArray();
