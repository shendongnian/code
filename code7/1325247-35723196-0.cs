    var result = queryResult.OrderBy(c => c.TariffName)
                            .Take(count);
    var list = result.ToList().Select(c => new
                                {
                                    Text = c.TariffName + " - " + c.LineRental.ToString(),
                                    Key = c.TariffId,
                                    Price = c.LineRental
                                });
