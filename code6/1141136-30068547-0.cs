     private void btnAnalyze_Click(object sender, RoutedEventArgs e)
     {      
           //#1      
           var task = Task.Factory.StartNew(() => { 
               //#2      
           });
           var continuationTask = task.ContinueWith(f =>
           {
               //#3                        
           });
    
           continuationTask.Wait();
           //#4      
     }
