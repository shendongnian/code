    // namespace should match the namespace in your reference.cs
    namespace MyCompany.MyApp.Service
    {
    	[DebuggerDisplay("Example")]
    	[DebuggerTypeProxy(typeof(InternalProxy))]
    	public partial class Example // name of your DataContract class in the reference.cs
    	{
    		internal class InternalProxy
    		{
    			private Example _realClass;
    			// the debugger instantiate this class
    			// with a reference to the instance being watched
    			public InternalProxy(Example realClass)
    			{
    				_realClass = realClass;
    			}
    
    			[DebuggerDisplay("Description = {Proxiedproperty}")]
    			public string Proxiedproperty {
    			    // description is a genereated property
    				get { return _realClass.description; }
    			}
                        
                        // add other properties if needed
    		}
    	}
    }
