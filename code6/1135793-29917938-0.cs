                MyDto dto = null;
                var myDtoList = session.QueryOver<File>()
                    .Select(
                        Projections.Group<File>(x => x.Region).WithAlias(() => dto.Region),
                        Projections.Sum(
                            Projections.Conditional(
                                Restrictions.Where<File>(c => c.ShowLocation== 1),
                                Projections.Constant(1),
                                Projections.Constant(0))).WithAlias(() => dto.ShowCount),
                        Projections.Sum(
                            Projections.Conditional(
                                Restrictions.Where<File>(c => c.ShowLocation== 0),
                                Projections.Constant(1),
                                Projections.Constant(0))).WithAlias(() => dto.NotShowCount))
                    .TransformUsing(Transformers.AliasToBean<MyDto>())
                    .List<MyDto>();
