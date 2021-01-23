    // Useful extension method
    private static IEnumerable<InstanceProducer> GetDependencies(this InstanceProducer p) {
        foreach (var r in p.GetRelationships()) {
            yield return r.Dependency;
            foreach (var d in r.Dependency.GetDependencies()) {
                yield return d;
            }
        }
    }
    var container = new Container();
    // Do registrations
    // You need to verify to get the correct output of those methods
    container.Verify();
    var deps = container.GetRegistration(typeof(A1)).GetDependencies();
    Assert.IsTrue(deps.Any(p => p.Registration.ImplementationType == typeof(C1)));
