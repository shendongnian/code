    orderDto.ShouldBeEquivalentTo(order, options => 
    options.ExcludingMissingMembers());
    orderDto.ShouldBeEquivalentTo(order, options => 
    options.Excluding(o => o.Customer.Name));
    orderDto.ShouldBeEquivalentTo(order, options => options 
    .Excluding(ctx => ctx.SelectedMemberPath == "Level.Level.Text")); 
