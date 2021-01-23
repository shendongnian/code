    if (stopwatch.ElapsedMilliseconds >= 3000)
    {
        if (stopwatch.ElapsedMilliseconds > 5000)
        {
             Assert.Fail("Error");
        }
        else
        {
            // Generate warning
            Assert.Fail("Warning");
        }
    }
