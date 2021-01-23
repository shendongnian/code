    if (textElement != null)
    {
        // get the table containing the matched text element and clone it
        Table table = textElement.Ancestors<Table>().First();
        Table tableCopy = (Table)table.CloneNode(deep: true);
        // do stuff with copied table (see below)
    }
