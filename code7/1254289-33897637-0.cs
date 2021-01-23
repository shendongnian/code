    _session.QueryOver<Negocio>()
        .JoinQueryOver(x => x.Endereco)
        .JoinQueryOver(x => x.GeoCoordenada)
        .WhereRestrictionOn(x => x.Latitude).IsBetween(-90).And(90)
        .AndRestrictionOn(x => x.Longitude).IsBetween(-180).And(180)
        .OrderBy(
            new ArithmeticOperatorProjection(
                "+",
                NHibernateUtil.Decimal,
                new ArithmeticOperatorProjection(
                    "*",
                    NHibernateUtil.Decimal,
                    new ArithmeticOperatorProjection("-", NHibernateUtil.Decimal, Projections.Property<GeoCoordenada>(x => x.Longitude), Projections.Constant(25m)),
                    new ArithmeticOperatorProjection("-", NHibernateUtil.Decimal, Projections.Property<GeoCoordenada>(x => x.Longitude), Projections.Constant(25m))
                ),
                new ArithmeticOperatorProjection(
                    "*",
                    NHibernateUtil.Decimal,
                    new ArithmeticOperatorProjection("-", NHibernateUtil.Decimal, Projections.Property<GeoCoordenada>(x => x.Latitude), Projections.Constant(25m)),
                    new ArithmeticOperatorProjection("-", NHibernateUtil.Decimal, Projections.Property<GeoCoordenada>(x => x.Latitude), Projections.Constant(25m))
                )
        )
        .List();
