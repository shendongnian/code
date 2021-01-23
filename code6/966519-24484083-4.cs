    public class tempTable 
    { 
       private string _FieldName;   //don't use static
       private double _FieldValue;  //don't use static
       public string FieldName { get { return _FieldName; } set { _FieldName = value; } }
       public double FieldValue { get { return _FieldValue; } set { _FieldValue = value;} }     
    }       
