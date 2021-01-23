    myActualObject.ShouldBeEquivalentTo(myExpectedObject, options => options
        .Using<double>(dbl =>
           { 
               if (!double.IsNaN(dbl.Subject))
               {
                  dbl.Subject.Should().BeApproximately(dbl.Expectation, ABS_ERROR);
               }
           })
        .WhenTypeIs<double>()
    );
