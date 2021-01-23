     public class UserUnitMapper:
            IMapToNew<UnitViewModel, UserUnit>
        {
            public UnitViewModel Map(UserUnit source)
            {
                return new UnitViewModel
                {
                    Name = source.Name,
                    ...
                };
            }
        }
