    parsedList.Where(line => line[0]== 'D' && line[55] = 'Y')
      .ToList()
      .ForEach(line => {
        item.PostalCode5(line.Substring(1, 5)),
        item.PreferredCityName28(line.Substring(13,28))
      });
