    //...
    var value = Row.Cells[2].Value;
    if (value == null || value == DBNull.Value)
    { 
        // Error ...
    }
    else
    {
        var type = (MyType)value;
        // Check if type contains a valid value ...
    }
