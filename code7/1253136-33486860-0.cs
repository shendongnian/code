    static void Main()
    {
	// Create task and start it.
	// ... Wait for it to complete.
	Task task = new Task(AsyncMethod);
	task.Start();
	task.Wait();
    }
    public static async void AsyncMethod(){
    await AnotherMehod();}
    static async Task AnotherMehod() { //TODO}
