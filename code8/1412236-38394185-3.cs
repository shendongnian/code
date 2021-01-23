     // No side effect: just answer is running or not
     public bool IsRunning {
       get {
         return (move != Moving.None) && staminaRegan && KeyState.IsKeyDown(Keys.Space);
       }
     }
     // Put the right interval based on instance internal state 
     // (if it's running etc.)
     public void AdjustInterval() {
       if (IsRunning) // and may be other conditions
         EntityAnimation.interval = 10; //TODO: move magic number into constant 
       else 
         EntityAnimation.interval = 65; //TODO: move magic number into constant
     } 
