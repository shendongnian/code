        class TriggerSubscriber : ISubscriber
        {
            public void HandleMessage(IMessage message)
            {
              var triggerMessage = message as TriggerMessage;
              if(triggerMessage != null)
              {
                 // Casting is not necessary, but I'd still put it
                 // here just to make it clear
                 HandleMessage((TriggerMessage)triggerMessage);
                 return;
              }
              // other code
            }
            public void HandleMessage(TriggerMessage message)
            {
            }
        }
