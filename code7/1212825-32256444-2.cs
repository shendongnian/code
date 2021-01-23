    var creaturelist = new List<string>();
    var list = creatures.Select(t => t.Title).ToList();
    var section = list.GroupBy(c => c, (a, b) => new { Title = a, Count = b.Count() });
    foreach (var item in section)
    {
        creaturelist.Add(string.Format("{0}x {1}", item.Count, item.Title));
    }
    var vm = new ViewDeck();
    vm.Deck = deck;
    vm.CardList = cardlist;
    vm.Creatures = creaturelist;
    return View(vm);
