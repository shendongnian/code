    public class CustomContext : DefaultValidationContext //:IValidationContext
    {
        //Define the rules and rule Bindings
    }
    
    public class Rule1 : IMessageRule
    {
        //Check whatever you want in the fully parsed message
        //For example, check for the mandatory segment, groups cardinalities etc.
    }
