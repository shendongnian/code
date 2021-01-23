    StringBuilder sb = new StringBuilder();
    foreach (string line in fileContents) 
    {
        if (isKeyValuePair(line))
           sb.AppendLine(line); // Exception of type 'System.OutOfMemoryException' was thrown.
    }
