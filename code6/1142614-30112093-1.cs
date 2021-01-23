    private void UpdateValuesInDb();
    {
        // Code for updating the values.
        // The below method should be called in sequence 
        // and labels updated in the same sequence.
        // for type "1" .. "4".
        MoveValuesToNewDbDeleteFromSourceDb("1", values); 
        MoveValuesToNewDbDeleteFromSourceDb("2", values); 
        MoveValuesToNewDbDeleteFromSourceDb("3", values); 
        MoveValuesToNewDbDeleteFromSourceDb("4", values); 
    }
