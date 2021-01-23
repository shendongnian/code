    Immutable a = new Immutable(1);
    Immutable originalA = a;
    Debug.Assert(a.Value == 1);
    Debug.Assert(a == originalA); // Same instance (obviously).
    a++;
    Debug.Assert(a.Value == 2);
    Debug.Assert(a != originalA); // New instance.
