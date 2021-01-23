     public class UnitMapper:
            IMapToNew<UnitViewModel, Unit>
        {
            public UnitViewModel Map(Unit source)
            {
                return new UnitViewModel
                {
                    Name = source.Name,
                    ...
                };
            }
        }
