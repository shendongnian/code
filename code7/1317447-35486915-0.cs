            // If there is a filter applied then enter the loop if there isn't then the filter expression will be empty 
            if (!String.IsNullOrEmpty(filterExpression))
            {                
                // Create a new list of strings to hold the sequence ids
                List<string> sequenceIds = new List<string>();
                // For each row in the radgrid...
                foreach (GridDataItem row in rgCallRecordings.Items) // loops through each rows in RadGrid
                {
                    // ...Add the sequence id to the list
                    sequenceIds.Add(row.GetDataKeyValue("SEQUENCE_ID").ToString());                    
                }
                // Only return results whose sequence ids are in the list
                results = results.Where(a => sequenceIds.Contains(a.SEQUENCE_ID));                
            }    
