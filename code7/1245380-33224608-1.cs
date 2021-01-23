     public class OtherThing
     {
           public OtherThing(EventManager eventManager)
           {
               eventManager.EntityCreate += this.EventManager_EntityCreate;
           }
 
           void EventManager_EntityCreate(object sender, EntityCreatedEventArgs args)
           {
           }
     }
     
