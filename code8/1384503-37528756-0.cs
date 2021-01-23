     static void Main(string[] args)
            {
                Dictionary<string, object> inputs = new Dictionary<string, object>();            
                inputs.Add("userName", "Test User");         
    
                // Using DynamicActivity for this sample so that we can have an
                // InArgument, and also do everything without XAML at all
                DynamicActivity codeWorkflow = new DynamicActivity();
                codeWorkflow.Name = "MyScenario.MyDynamicActivity";
                foreach (var key in inputs.Keys)
                {
                    DynamicActivityProperty property = new DynamicActivityProperty();
                    property.Name = key;
                    property.Type = typeof(InArgument<Dictionary<string,object>>);                
                    codeWorkflow.Properties.Add(property);
                }
                codeWorkflow.Implementation = () => new WriteLine
                {
                    Text = new CSharpValue<string>
                    {
                        ExpressionText = "\"hello ! \" + InArguments[\"userName\"].ToString()"
                    },
                };         
                Compile(codeWorkflow);
                WorkflowInvoker.Invoke(codeWorkflow,
                 new Dictionary<string, object>
                    {
                { "InArguments", inputs}
                    });
    
                Console.ReadLine(); 
            }
