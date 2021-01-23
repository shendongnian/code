    Debug.Assert((Test.All & Test.None) == Test.None);
    Debug.Assert((Test.All & Test.X) == Test.X);
    Debug.Assert((Test.All & Test.All) == Test.All);
    Debug.Assert((Test.None & Test.None) == Test.None);
    Debug.Assert((Test.None & Test.X) == Test.None);
    Debug.Assert((Test.None & Test.All) == Test.None);
