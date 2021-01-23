    myActualObject.ShouldBeEquivalentTo(myExpectedObject, options => options
        .Using<double>(dbl =>
           { 
               if (!Double.IsNan(dbl.Subject())
               {
                  dbl.Subject.Should().BeApproximately(dbl.Expectation, ABS_ERROR));
               }
           }
        .WhenTypeIs<double>()
    );
