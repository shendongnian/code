    private void StopInventory(object obj)
    {
        ReaderAPI.Actions.Inventory.Stop();
        timer.Change( Timeout.Infinite , Timeout.Infinite ) ;
    }
