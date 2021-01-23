    private List<Row> CopyVolatileList(IEnumerable<Row> original)
    {
        while (true)
        {
            try
            {
                List<Row> copy = new List<Row>();
                foreach (Row row in original) {
                    copy.Add(row);
                }
                // Validate.
                if (copy.Count != 0 && copy[copy.Count - 1] == null) // Assuming Row is a reference type.
                {
                    // At least one element was removed from the list while were copying.
                    continue;
                }
                return copy;
            }
            catch (InvalidOperationException)
            {
                // Check ex.Message?
            }
                
            // Keep trying.
        }
    }
