     A.CallTo(() => repAssign.FindAll(
         A<DateTime>.Ignored,
         A<DateTime>.Ignored,
         A<Guid>.Ignored,
         A<Gender>.Ignored,
         A<Int>.Ignored))
     .ReturnsLazily(call =>
         list
           .Where(x => call.GetArgument<Int>(4) > 1)
           .ToList()
        );
