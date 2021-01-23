    using (var manager = new DocXManager(path))
    {
         manager.FrobDoxX(frobber);
         manager.MakeChangesAndSaveDocX();
    } //manager is guaranteed to be disposed at this point (ignoring scenarios where finally blocks are not executed; StackOverflowException, OutOfMemoryException, etc.)
