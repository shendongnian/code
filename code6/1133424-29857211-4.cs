    public class MyDto
    {
        public string Corporation { get; set; }
        public DateTime? CalculationDate { get; set; }
        public string ValuationRule { get; set; }
    }
    var result = Session.QueryOver<MyEntity>()
        .Where(x => x.State == State.Pending)
        .SelectList(list => list
            .Select(Projections.Distinct(Projections.Property<MyEntity>(x => x.Corporation))).WithAlias(() => myDto.Corporation)
            .Select(x => x.CalculationDate).WithAlias(() => myDto.CalculationDate)
            .Select(x => x.ValuationRule).WithAlias(() => myDto.ValuationRule)
            )
        .TransformUsing(Transformers.AliasToBean<MyDto>())
        //.TransformUsing(Transformers.AliasToBean<MyEntity>()) // You can use your entity but i recommend to use a DTO (Use MyEntity in the alias too)
        .ToList();
