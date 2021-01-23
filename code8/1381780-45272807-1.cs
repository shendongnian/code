    public static void WriteWithNullCheck<T>(this NpgsqlBinaryImporter writer, T value,NpgsqlDbType type)
            {
                if (value == null)
                {
                    writer.WriteNull();
                }
                else
                {
                    writer.Write(value, type);
                }
            }
