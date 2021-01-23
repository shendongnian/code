    class Row
    {
        public string Car {get; set;}
        public string Color {get; set;}
        public int Age {get; set;
    }
    
    void Validate(List<Row> rows)
    {
       //I did not use "var" to make it more obvious what is going on, in production code I would use "var".
       ILookup<string, Row> rowLookup = rows.ToLookup((row)=>row.Car);
    
       foreach(IGrouping<string, Row> carKey in rowLookup)
       {
           //This loop would loop once for Ford, once for Toyota
           foreach(Row row in carKey)
           {
               //This loop would loop twice in the Ford iteration and lope once in the Toyota iteration. 
               DoValidate(row);
           }
       }
    }
