    public string GenerateRow(Customer customer) { // convert one object here} 
    public string GenerateTable<T>(List<T> objects, Func<T,string> rowGenerator) 
    {
       // table boilerplate
       foreach(var obj in objects) {
         output.Append(rowGenerate(customer)) 
       }
    }
