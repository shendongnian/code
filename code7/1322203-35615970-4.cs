    class CustomCancellationTokenSource : CancellationTokenSource
    {
      public bool WasManuallyCancelled {get; private set;}
    
      public new void Cancel()
      {
        WasManuallyCancelled = true;
        base.Cancel();
      }
    }
