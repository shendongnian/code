    var comboItem = new ComboBoxItem();
    
    var result = Session.QueryOver<Person>()
      .WhereRestrictionOn(person => Projections.Concat(person.firstname, " ", person.lastname))
      .IsInsensitiveLike("%bob%")
      .OrderBy(person => person.lastname)
      .Asc
      .ThenBy(person => person.firstname)
      .Asc
      .SelectList(list => list
        .Select(person => person.ID).WithAlias(() => comboItem.id)
        .Select(person => Projections.Concat(person.firstname, " ", person.lastname)).WithAlias(() => comboItem.text)
      )
      .TransformUsing(Transformers.AliasToBean<ComboBoxItem>())
      .Skip(50)
      .Take(50)
      .List<ComboBoxItem>()
      .ToList();
