	static void FormuotiAtsisiktini(List<Klausimas> KlausimuList, ref List<Klausimas> Atsitiktinis)
    {
         Random kiek = new Random();
        int kiekis = kiek.Next(1, KlausimuList.Count);
		
		HashSet<Klausimas> hashset= new HashSet<Klausimas>();
		
        for (int i = 0; i < kiekis;)
		{
			i+=  hashset.Add(KlausimuList[kiek.Next(1, KlausimuList.Count)])?  1:0; // returns true when successfully added.
		}
		
		Atsitiktinis = hashset.ToList();    		
    }
