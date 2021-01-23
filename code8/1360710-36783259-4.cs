    double precision = 0.1;
    calculated.ShouldBeEquivalentTo(b, options => options
        .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, precision))
        .When(info => info.SelectedMemberPath == "X" ||
                      info.SelectedMemberPath == "Y" ||
                      info.SelectedMemberPath == "Z"));
