    public class Field{ 
        public string FieldName {get;set;}
        public int LookupID {get;set;}
        public string FieldAr {get;set;}
        public string FieldEn {get;set;}
    }
    var field1 = new Field(){ FieldName = "lastPrice", LookupID = 1, FieldAr = "اخر سعر", FieldEn = "last price" };
    //init other field here
    var fields = new List<Field>() {field1};
    var fieldsString = JsonConvert.SerializeObject(fields); 
