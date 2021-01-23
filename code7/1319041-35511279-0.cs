     @foreach (var item in Model.Where(x => x.Date == this.Date)
                    .Select(x => new 
                    {
                     Rid = x.Rid,
                     Total = x.Total
                     })
                     .GroupBy(l => l.Rid) //and then grouping
                     .Select(z => new
                     {
                     Turno = z.Key,
    Total = Decimal.Round(z.Sum(l => l.Total), 0)
                      }))
                     {
                    <input value="@item)" />
                      }
