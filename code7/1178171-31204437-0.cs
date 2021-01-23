    public static class DbExtensions
    {
        public static IDbCommand CreateCommand(this IDbConnection connection, FormattableString commandText)
        {
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            if (commandText.ArgumentCount > 0)
            {
                var commandTextArguments = new string[commandText.ArgumentCount];
                for (var i = 0; i < commandText.ArgumentCount; i++)
                {
                    commandTextArguments[i] = "@p" + i.ToString();
                    command.AddParameter(commandTextArguments[i], commandText.GetArgument(i));
                }
                command.CommandText = string.Format(CultureInfo.InvariantCulture, commandText.Format, commandTextArguments);
            }
            else
            {
                command.CommandText = commandText.Format;
            }
            return command;
        }
    }
