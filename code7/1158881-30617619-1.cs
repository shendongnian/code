    using System; 
    using System.ComponentModel; 
    using System.IO;
    using System.Runtime; 
    using System.Activities.Validation;
    using System.Collections.Generic;
    using System.Windows.Markup;
    using System.Collections.ObjectModel;
    using System.Activities; 
    namespace WorkflowConsoleApplication2
    {
   
    public sealed class CodeActivity1 : CodeActivity
    {
        // Define an activity input argument of type string
        [DefaultValue(null)]
        public InArgument<string> Test
        {
            get;
            set;
        }
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            RuntimeArgument textArgument = new RuntimeArgument("Test",    typeof(string), ArgumentDirection.In);
            metadata.Bind(this.Test, textArgument);
            metadata.SetArgumentsCollection(
            new Collection<RuntimeArgument> 
            {
                textArgument,
            });
        }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine(this.Test.Get(context)); 
        }
     }
