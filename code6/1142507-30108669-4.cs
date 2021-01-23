    public class MiddleTier
    {
         public event ProcessedEventHandler RecordProcessed;
         //NOTE it would be best to make a tweak to do this asynchronously
         //such that all records can be processed at the same time instead
         //of processing them sequentially. if the method were async, you
         //could do all of this without the method itself blocking.
         public void Process()
         {             
             //this loop/processing should ideally be asynchronous
             foreach(var thing in whatever)
             {
                 //process thing 
 
                 //make event args
                 var args = new MyEventArgs(); //fill out properties
                 //raise event
                 OnProcessed(args);
             }
             private void OnProcessed(MyEventArgs args)
             {
                  //follow this pattern for thread safety
                  var p = RecordProcessed;
                  if(p != null)
                       p(this, args);
             }
         }
    }
