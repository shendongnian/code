            StringBuilder logger = new StringBuilder();
            foreach (var column in Schema.Select(pair => pair))
            {
                ParseIntAndOrWriteFailMessage(row, logger, column.Key);
            }
            // Parsed values are now stored in the Schema Dictionary (which probably could use a better name)
