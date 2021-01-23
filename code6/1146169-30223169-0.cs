    private static IEnumerable<Employee> Function1() {
        yield return new Employee { Id = 1, Name = "John" };
        yield return new Employee { Id = 2, Name = "Mary" };
    }
    ViewState.Add("str", Source1.ToArray());
