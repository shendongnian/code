    // this WHERE
    // .Where(_ => _.SomeOtherEntity.Id == otherEntity.Id) // here we consume 
    // into this HAVING
    .Where(Restrictions.EqProperty(
        Projections.Max<SomeOtherEntity >(x => x.MaxPerGroupProperty),
        Projections.Property(() => otherEntity.GroupProperty)
    ))
