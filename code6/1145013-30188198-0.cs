    public class ComboBoxItem()
    {
         string displayValue;
         string hiddenValue;
         //Constructor
         public ComboBoxItem (string d, string h)
         {
              displayValue = d;
              hiddenValue = h;
         }
         //Accessor
         public string HiddenValue
         {
              get
              {
                   return hiddenValue;
              }
         }
         public override bool Equals(object obj)
         {
             ComboBoxItem item = obj as ComboBoxItem;
             if (item == null)
             {
                return false;
             }
             return item.hiddenValue == this.hiddenValue;
         }
         public override int GetHashCode()
         {
             if (this.hiddenValue == null)
             {
                 return 0;
             }
             return this.hiddenValue.GetHashCode();
         }
         //Override ToString method
         public override string ToString()
         {
              return displayValue;
         }
      }
