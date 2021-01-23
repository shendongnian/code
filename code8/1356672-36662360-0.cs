    static List<Klausimas> FormuotiAtsisiktini(List<Klausimas> KlausimuList)
    {
      Random kiek = new Random();
      List<Klausimas> source = new List<Klausimas>(KlausimuList);
      List<Klausimas> result = new List<Klausimas>();
      int kiekis = kiek.Next(1, KlausimuList.Count);
      for (int i = 0; i < kiekis; i++)
      {
        var match = source[kiek.Next(0, source.Count - 1)];
        result.Add(match);
        source.Remove(match);
      }
      return result;
    }
