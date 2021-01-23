        string aa = "22.333";
		string bb = "22";
		string cc = "22.4444";
		
		decimal d = decimal.Parse(aa);
		decimal e = decimal.Parse(bb);
		decimal f = decimal.Parse(cc);
		
		Console.WriteLine(string.Format("{0:0.000}", d));
		Console.WriteLine(string.Format("{0:0.000}", e));
		Console.WriteLine(string.Format("{0:0.000}", f));
