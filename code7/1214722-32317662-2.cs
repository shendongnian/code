    public class TimeNow : System.Web.UI.Control
    {
         private readonly Literal literal;
         public TimeNow()
         {
             this.literal = new Literal();
             // ... and set the Text etc., no one else can access
         }
         // or something like this
         public TimeNow(ILiteralFactory literalFactory)
         {
             // the factory is just an example... don't know your context but this way your newly created literal can't be accessed
             this.literal = literalFactory.CreateNewLiteral();
             // do what you want with the text control, e.g. store internally
             // Clone() the Literal etc.
             // the
         }
    }
