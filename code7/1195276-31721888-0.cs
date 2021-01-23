    const string query = "
    select TeamName, count(*) 
     from NetHoz_Decision
     inner join NetHoz_Case on NetHoz_Decision.CaseDisplayIdentifier = NetHoz_Case.CaseDisplayIdentifier 
     inner join maintik on MainTik.Counter = NetHoz_Case.TikCounter
     inner join Teams on MainTik.TeamCounter = Teams.Counter
     where NetHoz_Decision.DecisionStatusChangeDate between @from and @to
     group by TeamName
    ";
    
    SqlCommand command = new SqlCommand(query);
    command.Parameters.AddWithValue("@from", dateTimePicker1.Value);
    command.Parameters.AddWithValue("@to", dateTimePicker2.Value.AddDays(1));
