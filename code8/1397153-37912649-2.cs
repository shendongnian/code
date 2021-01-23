    public class CustomTimer
    {
        List<Action> _oneTimeActions = new List<Action>();
    
        public void SubscribeOnce(Action handler)
        {
             lock(_oneTimeActions) 
             { 
               _oneTimeActions.Add(handler);
             }
        }
               
           
        protected virtual void OnOneSecond(object sender, ElapsedEventArgs elapsedEventArgs)
        {
               
              // get a local copy of scheduled one time items
              // removing them from the list. 
              Action[] oneTimers;
              lock(_oneTimeActions)
              {
                  oneTimers = _oneTimeActions.ToArray();
                  _oneTimeActions.Clear();
              }     
              // Execute periodic events first
              this.OneSecond?.Invoke();
              // Now execute one time actions
              foreach(var action in oneTimers)
              {
                  action();
              }
        }
    }  
