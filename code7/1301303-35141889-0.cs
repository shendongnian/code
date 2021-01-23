    private void dataGridView2_ColumnHeaderMouseClick(
        object sender, DataGridViewCellMouseEventArgs e)
    {
        ...
        var sortCol = dataGridView2.Columns[e.ColumnIndex];
        var colName = sortCol.Name;
    
        dataGridView2.DataSource = listPlayers.Select(s => new { voornaam = s.Voornaam, Achternaam = s.Achternaam, positie = s.Positie, Nationaltieit = s.Nationaliteit, Leeftijd = s.Age, Aanval = s.Aanval, Verdediging = s.Verdediging, Gemiddeld = s.Gemiddeld, waarde = s.TransferWaarde })
                                              .OrderBy(s => typeof(SpelerData).GetProperty(colName))
                                              .ToList();
        ...
    }
