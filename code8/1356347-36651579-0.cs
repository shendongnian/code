    public void TryAcceptPredicateMethod(Func<PackagedClassWithProperty> p) {
        Console.WriteLine(p.DesiredTargetProperty);
    }
    public void TryCallAcceptPredicateMethod() {
        // n should be a variable or something in the type of ContainingParentClassWithProperties 
        TryAcceptPredicateMethod(() => n.OptionOne);
    }
