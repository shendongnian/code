    public AlphaKeypad(Func<DataTable> func) {
        ....
    }
    
    // somewhere else
    new AlphaKeypad(()=> return new DataTable());
    
    // or
    DataTable FunctionReturningDataTable() {
        return ....;
    }
    ....
    new AlphaKeypad(FunctionReturningDataTable); // no brackets means, the function will be passed, not the result of call
