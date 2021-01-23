    public void CallPossiblyInconclusiveMethod(Action something) {
        try {
            something();
        }
        catch (Exception ex) {
            if (ex is ISomeNonCriticalException) Assert.Inconclusive();
            else throw;
        }
    }
