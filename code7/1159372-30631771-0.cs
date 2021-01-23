    `private void AtomicRunSimulationRound(GWDatabase db, GameModel game)
    {
        lock(SimulationLock) //Ensure that only 1 thread has access to the method at once
        {
            TryToRunSimulationRound(db, game);
        }
    }
    
    private void TryToRunSimulationRound(GWDatabase db, GameModel game)
    {
        //Thread.sleep is not needed anymore
    }`
