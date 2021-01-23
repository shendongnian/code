    static class FbCommandExtension
    {
        public static void ExecuteBatch(this FbCommand cmd)
        {
            var script = new FbScript(cmd.CommandText);
            script.Parse();
            foreach (var line in script.Results)
            {
                using (var inner = new FbCommand(line.Text, cmd.Connection, cmd.Transaction))
                {
                    CopyParameters(cmd, inner);
                    inner.ExecuteNonQuery();
                }
            }
        }
        private static void CopyParameters(FbCommand source, FbCommand inner)
        {
            foreach (FbParameter parameter in source.Parameters)
            {
                inner.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            }
        }
    }
