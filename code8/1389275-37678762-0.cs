    public class User
       {
           public object Name { get; set; }
           public string DataType { get; set; }
           public Control Current_Value
           {
               get;
               set;
           }
           public string _PhysicalValueTxtChanged = null;
           public string PhysicalValueTxtChanged
           {
               get { return _PhysicalValueTxtChanged; }
               set
               {
                   _PhysicalValueTxtChanged = value;
               }
           }
           public Control ToDo { get; set; }
           
       }
