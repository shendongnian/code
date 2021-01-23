    myActualObject.ShouldBeEquivalentTo(myExpectedObject, options => options
        .Using<double>(dbl =>
           { 
               if (!double.IsNaN(dbl.Subject))
               {
                   String errorMessage = string.Format("{0} caused the assertion to fail",myExpectedObject);
                   dbl.Subject.Should().BeApproximately(dbl.Expectation, ABS_ERROR, errorMessage);
               }
           })
        .WhenTypeIs<double>()
    );
