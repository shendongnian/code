    [Cmdlet(VerbsCommon.Get, "Foo",
        SupportsShouldProcess = true
        )]
    public class GetFooCommand : PSCmdlet, IDynamicParameters
    {
        // First things first: Lets try making a dictionary for our return 
        // value in our implementation of IDynamicParameter's 
        // GetDynamicParameters() method
        private RuntimeDefinedParameterDictionary DynamicParameters;
        [Parameter]
        public string MyString { get; set; }
        [Parameter]
        public int MyInt { get; set; }
        [Parameter]
        // Booleans are not as fun as SwitchParameters, IMHO
        public bool MyBool { get; set; }
        // Remember that SwitchParameter is really just a boolean (sort of), so 
        // it will default to 'false'
        [Parameter]
        public SwitchParameter MySwitch { get; set; }
        public object GetDynamicParameters()
        {
            // You only want this to run when the switch is flipped,
            // so try it this way and see if it works for you
            if (MySwitch)
            {
                // Create the dictionary. We will return this at the end because
                // **** spoiler alert **** it is an object :)
                var runtimeParameterDictionary = new RuntimeDefinedParameterDictionary();
                // Lets make that parameter now. Your example doesn't specify any 
                // additional parameter attributes beyond the required "ParameterAttribute", 
                // so here we create an empty Attribute Collection
                var runtimeParameter = 
				new RuntimeDefinedParameter("Bar", typeof (string), new Collection<Attribute>());
                // With a new Parameter, lets add it to our dictionary. 
                runtimeParameterDictionary.Add("Bar", runtimeParameter);
                // Because we created a field for our dictionary way up top, we can assign it like I
                // illustrate below. This will enable easy, predictable results when we seek to 
                // extract the values from the dictionary at runtime.
                DynamicParameters = runtimeParameterDictionary;
                // Note: You can add as many parameters as you want this way, and that Is 
                // why I recommend it to you now. Coding the parameters as classes outside of the 
                // Cmdlet, and to some extent as embedded Classes,
                // within the Cmdlet Never really worked for me, so I feel your pain/frustration.
                return runtimeParameterDictionary;
            }
            return null; // Guess the user doesn't want that Bar afterall;
        }
        protected override void ProcessRecord()
        {
            // We obviously want to sequester everything we are doing with the dynamic
            // parameters so a good-old-fashioned if.. then.. else... will suffice.
            if (MySwitch)
            {
                // Now we are here at the precipice of this DynamicParameter cmdlet.
                // Here is one way to get the value desired from the dynamic parameter.
                // Simply access it like a dictionary...
                var bar = DynamicParameters["Bar"].Value as string;
                // The reason we can do it this way is because we assigned our
                // beloved value to the local variable "DynmaicParameters"
                // in the GetDynamicParameters() method. We could care less about 
                // the return value, because if the 
                // switch is flipped, "DynamicParameters" will be our new best friend, and
                // it will have everything we need.
                WriteWarning("Your " + bar + " has been forwarded to an automatic voice messaging system ...");
            }
            WriteObject("Cheers was filmed before a live studio audience...");
            WriteObject(MyInvocation.BoundParameters);
        }
    }
