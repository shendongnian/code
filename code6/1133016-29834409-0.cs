    // Send a notification
    pubsub.Notify();
    
    pubsub.Subscribe
    (
         () =>
         {
              // Do stuff here if I receive a notification
         }
    );
