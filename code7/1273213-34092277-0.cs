SqlCommand command = new SqlCommand(commandText, connection);
connection.Open();
IAsyncResult result = command.BeginExecuteNonQuery();
while (!result.IsCompleted)
{
    Console.WriteLine("Waiting ({0})", count++);
    // Wait for 1/10 second, so the counter
    // does not consume all available resources 
    // on the main thread.
    System.Threading.Thread.Sleep(100);
}
Console.WriteLine("Command complete. Affected {0} rows.", 
                    command.EndExecuteNonQuery(result));
