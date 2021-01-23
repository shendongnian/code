    var tasks = new Task<//return type of UserDetails.InsertOneAsync(um)>[//get collection count here];
    var count = 0;
    foreach(// iterate collection here)
    {
    try {
                tasks[count] = UserDetails.InsertOneAsync(um); // adds continuations and return back immediately i.e. no blocking
                count++;
            } catch(Exception) {
        }
    }
    await Task.WhenAll(tasks.ToArray()); // here is where we block all tasks and wait for completion
