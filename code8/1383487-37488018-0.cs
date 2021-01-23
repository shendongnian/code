    List<Person> lista = GetPersons();
    ListItemCollection items = ListBox1.Items;
    foreach (ListItem item in items)
    {
      if (item.Selected == true)
      {
        // Here I retrieve the PersonType by matching the ID
        var person = lista.FirstOrDefault( person => person.PersonId == item.value);
        // You may want to check for null...
        string personType = person.PersonType;
      }
    }
