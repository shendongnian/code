    public class BetterDateTimeField : FieldReflector<MyOrder> 
    {
      public BetterDateTimeField(string name, bool ignoreAnnotations = false) 
              : base(name, ignoreAnnotations)  { }
    
       public override IForm<MyOrder> Form
       {
          set
          {
            base.Form = value;
            base.SetRecognizer(new BetterDateTimeRecognizer<MyOrder>(this, CultureInfo.CurrentCulture));
          }
        }
    }
