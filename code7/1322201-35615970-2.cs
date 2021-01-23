    class CustomCancellationTokenSource : CancellationTokenSource
    {
      pubic bool WasManuallyCancelled {get; private set;}
    
      public new void Cancel()
      {
        WasManuallyCancelled = true;
        base.Cancel();
      }
    }
