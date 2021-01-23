    using System.Linq;
    ...
    var squadra = rdr.GetStringOrNull(6);
    if (MainWindow.AppWindow.Teams_DataGrid.Items.Cast<Team>().Any(t => t.Name == squadra))
    {
         MessageBox.Show("Squadra già inserita."); 
    }
    else 
    {
         MainWindow.AppWindow.Teams_DataGrid.Items.Add(new Team
         {
             Code = rdr.GetStringOrNull(7),
             Name = squadra,
             Championship = rdr.GetStringOrNull(4),
             ShortName = rdr.GetStringOrNull(8),
             SquadMarketValue = rdr.GetStringOrNull(9)
         });
     }
