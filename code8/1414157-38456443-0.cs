    DataTable source = _applicationManager.Retrieve(); // Populate DataTable
    source.Columns.Add("Messages", typeof(IMessages));
    // ------- changed code ------------------
    // this is just an example, you can also place a loop here
    // and iterate through all the lines in the DataTable and set the object
    // in the "Messages" column
    source.Rows[0]["Messages"] = messageobject; 
    // --------------------------------------------------
    dataGridView.DataSource = source;
