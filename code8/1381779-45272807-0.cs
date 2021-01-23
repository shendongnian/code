    public static void WriteWithNullCheck(this NpgsqlBinaryImporter writer, string value)
            {
                if (string.IsNullOrEmpty(value))
                {
                    writer.WriteNull();
                }
                else
                {
                    writer.Write(value);
                }
            }
