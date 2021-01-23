    var items = new List<Position>();
    for (int i = 0; i < 5; i++) {
          items.Add(new MockPosition { Size = i });
    }
    foreach (var item in items.Cast<MockPosition>()) {
           Console.Write("{0}\t", item.Size); //prints 0 1 2 3 4
    }
