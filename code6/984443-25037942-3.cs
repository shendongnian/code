       if (e.Key == Key.Enter)
       {
         Task.Factory.StartNew( () => {
           cmd.SetCommand(sp1, "top");
           cmd.SetCommand(sp1, "run");
           // .... //
         });
       }
