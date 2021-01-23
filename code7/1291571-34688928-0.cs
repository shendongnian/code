    // See constructor optional parameters to configure it according to your needs
    var listener = new SqlDependencyEx(connectionString, "YourDatabase", "YourTable");
    // e.Data contains actual changed data in the XML format
    listener.TableChanged += (o, e) => Console.WriteLine("Your table was changed!");
    // After you call the Start method you will receive table notifications with 
    // the actual changed data in the XML format
    listener.Start();
    // ... Your code is here 
    // Don't forget to stop the listener somewhere!
    listener.Stop();
