     // No side effect: just answer is running or no
     public bool IsRunning {
       get {
         return (move != Moving.None) && staminaRegan && KeyState.IsKeyDown(Keys.Space);
       }
     }
     // Put the right interval based on instance internal state 
     // (if it's running etc.)
     public void AdjustInterval() {
       if (IsRunning) // and may be conditions
         EntityAnimation.interval = 10;
       else 
         EntityAnimation.interval = 65; 
     } 
