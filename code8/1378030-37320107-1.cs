    List<CSVEntry> csvList = line.Select(l => l.Split(',')).
                  Select(col => {
                      CSVEntry entry = new CSVEntry { date = DateTime.ParseExact(col[7], "dd/MM/yyyy", null)};
                      if (entry.date == DateTime.Today)
                          date.bgColour = "40FFFF";
                      else if (entry.date > DateTime.Today)
                          date.bgColour = "FFFFFF";
                      else
                          date.bgColour = "FFFF40";
                      return entry;}).
                  OrderBy(csventry => csventry.date).ToList();
