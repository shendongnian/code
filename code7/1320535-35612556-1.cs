     public Task InitializeAsync(State someState)
     {
         if (State.IsActivated)
         {
             // log out here that someone is attempting to reactivate when they shouldn't
             return Task.CompletedTask;
         }
         
         State = someState;
         State.IsActivated = true;
         return Task.CompletedTask;
     }
