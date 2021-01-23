    // For the root object which contains the "UseCases" field
    public class RootObject
    {
        public UseCasesContainer UseCases { get; set; }
    }
    
    // For the "UsesCases" field, the tricky thing is that 
    // it's not a collection but an object
    public class UseCasesContainer
    {
         
        // ..which contains a collection field.
        public Collection<UsesCase> UsesCase { get; set; }
    }
