    void Button_Click(object sender, EventArgs e)
    {
         var context = SynchronizationContext.Current;
         // this is executred on the UI thread.
         context.Send(() =>
         {
               // this is also executed on the UI thread.
         });
         Task.Run(() =>
         {
             // this is executed on a worker thread
             context.Send(() =>
             {
                 // this is still executed on the UI thread!
             });
         }
         // what you are doing will always execute on a worker thread.
         var  myNewContext = new SynchronizationContext();
         SynchronizationContext.SetSynchronizationContext(myNewContext);
         myNewContext.Send(() =>
         {
             // this will run on a worker thread.
         }         
    }
