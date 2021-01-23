    private static string ObjectToString(IList<object> messages)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in messages)
            {
                if (builder.Length > 0)
                    builder.Append(" ");
                if (item is IList<object>)
                    builder.Append(ObjectToString((IList<object>)item));
                else
                    builder.Append(item);
            }
            return builder.ToString();
        }
