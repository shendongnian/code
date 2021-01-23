    var list = new List<int>();
    for (var i = 0; i <= 1000; i++)
    {
      list.Add(i);
    }
    static void iteratefrom5to10(IEnumerable<int> ien)
    {
      foreach (var value in ien)
      {
        MessageBox.Show(value.ToString());
      }
    }
