    /// <summary>
    ///     Deletes columns that are not needed from a given <see cref="System.Data.DataTable" /> reference.
    /// </summary>
    /// <param name="dt">
    ///     The <see cref="System.Data.DataTable" /> to delete columns from. 
    /// </param>
    /// <param name="engine">
    ///     The <see cref="FileHelperEngine" /> object containing data field usability information. 
    /// </param>
    private static void DataTableCleanUp(ref DataTable dt, ref FileHelperEngine engine)
    {
        // Tracks DataColumns I need to remove from my temp DataTable, dt.
        List<DataColumn> removeColumns = new List<DataColumn>();
        // If a field is Discarded, then the data was not imported because we don't need this
        // column. In that case, mark the column for deletion by adding it to removeColumns.
        for (int i = 0; i < engine.Options.Fields.Count; i++)
            if (engine.Options.Fields[i].Discarded)
                removeColumns.Add(dt.Columns[i]);
        // Reverse the List so changes to dt don't generate schema errors.
        removeColumns.Reverse();
        // Do the deletion.
        foreach (DataColumn column in removeColumns)
            dt.Columns.Remove(column);
        // Clean up memory.
        removeColumns.Clear();
    }
