`
var contextDblistener = this.contextDb.GetService<DiagnosticSource>();
(contextDblistener as DiagnosticListener).SubscribeWithAdapter(new SqlCommandListener());
`
The Interceptor itself then needs its Methods marked with the corresponding ```DiagnosticName``` Annotation.
The tweak i gave to the Interceptor was, that it looks for specific tags (sql comments) inside the command to single out the queries that should be extended with the desired option.
To mark a Query to use the recompile option, you simply have to add a ```.TagWith(Constants.SQL_TAG_QUERYHINT_RECOMPILE)``` to the query without bothering around with setting a bool to true and back to false.
This way you also don't have a problem with parallel Queries being intercepted and all being extended with a recompile option because of a single bool HintWithRecompile.
The constant tag strings are designed so that they can only be inside of an sql comment and not part of the query itself.
I could't find a solution to analyze only the tag part (implementation detail of EF), so the whole sql command is analyzed and you don't want to add a recompile because some text inside of the query matches your flag.
The "Optimize for Unknown" Part can be improved further by using the command parameter property, but i'll leave that up to you.
`
public class SqlCommandListener
{
    [DiagnosticName("Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting")]
    public void OnCommandExecuting(DbCommand command, DbCommandMethod executeMethod, Guid commandId, Guid connectionId, bool async, DateTimeOffset startTime)
    {
        AddQueryHintsBasedOnTags(command);
    }
    [DiagnosticName("Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted")]
    public void OnCommandExecuted(object result, bool async)
    {
    }
    [DiagnosticName("Microsoft.EntityFrameworkCore.Database.Command.CommandError")]
    public void OnCommandError(Exception exception, bool async)
    {
    }
       
    private static void AddQueryHintsBasedOnTags(DbCommand command)
    {
        if (command.CommandType != CommandType.Text || !(command is SqlCommand))
        {
            return;
        }
        if (command.CommandText.Contains(Constants.SQL_TAG_QUERYHINT_RECOMPILE) && !command.CommandText.Contains("OPTION (RECOMPILE)", StringComparison.InvariantCultureIgnoreCase))
        {
            command.CommandText = command.CommandText + "\nOPTION (RECOMPILE)";
        }
        else if (command.CommandText.Contains(Constants.SQL_TAG_QUERYHINT_OPTIMIZE_UNKNOWN_USER) && !command.CommandText.Contains("OPTION (OPTIMIZE FOR (@__SomeUserParam_0 UNKNOWN))", StringComparison.InvariantCultureIgnoreCase))
        {
            command.CommandText = command.CommandText + "\nOPTION (OPTIMIZE FOR (@__SomeUserParam_0 UNKNOWN))";
        }
    }
}
`
