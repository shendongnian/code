    Session.CreateCriteria<BookmarkEntity>()
           .CreateAlias("Tags", "t")
           .SetProjection(
             // Projections.Distinct(Projections.Property<BookmarkEntity>(b => b.Tags))
             Projections.Distinct(Projections.Property("t.elements"))
           )
           .AddOrder(Order.Asc(Projections.Property("t.elements")))
           .List<string>();
