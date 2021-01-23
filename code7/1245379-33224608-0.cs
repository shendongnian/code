     class EntityCreatedEventArgs : EventArgs
     {
          public Entity Entity {get; set; }
     }
     class EventManager
     {
          public event EventHandler<EntityCreatedEventArgs> EntityCreate;
        
          private void FireCreateEvent(Entity entity)
          {
              if(this.EntityCreate)
              {
                   this.EntityCreate(this, new EntityCreatedEventArgs { Entity = entity });
              }
          }
          // Rest of implementation
     }
