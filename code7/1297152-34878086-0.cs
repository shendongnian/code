      Guard.Ensure(a, "a")
        .IsNotNull("a is null");
      Guard.Ensure(a.p0, "a.p0")
        .IsGreaterThan(10);
      Guard.Ensure(a.p1, "a.p1")
        .IsGreaterThan(5);
