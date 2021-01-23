    var subquery = QueryOver.Of<TableA>()
        .JoinQueryOver(tabA => tabA.TableBItems)
            .Where(tabB => tabB.X == null || tabB.Y == null)
        .Select(Projections.Id());
    
    var s = Session.QueryOver<TableA>()
        .Where(tabA => tabA.SomeID == 123 && tabA.SomeNullableDate != null)
        .WhereRestrictionOn(Projections.Id()).NotIn(subquery)
        .JoinQueryOver(tabA => tabA.TableBItems)
            .Where(tabB => tabB.X != null && tabB.Y != null)
        .List<TableA>();
