    namespace YourNS
    {
    	public class Setter {
    		public string Property { get; set; }
    		public string Value { get; set; }
    	}
		[ContentProperty ("Children")]
		public class Style
		{
			public Style ()
			{
				Children = new List<Setter> ();
			}
			public IList<Setter> Children { get; private set; }
			public static readonly BindableProperty StyleProperty = 
				BindableProperty.CreateAttached<Style, Style> (bindable => GetStyle (bindable), default(Style), 
					propertyChanged: (bindable, oldvalue, newvalue)=>{
						foreach (var setter in newvalue.Children) {
							var pinfo = bindable.GetType().GetRuntimeProperty (setter.Property);
							pinfo.SetMethod.Invoke (bindable,new [] {Convert.ChangeType (setter.Value, pinfo.PropertyType.GetTypeInfo())});
						}
							
					});
			public static Style GetStyle (BindableObject bindable)
			{
				return (Style)bindable.GetValue (StyleProperty);
			}
			public static void SetStyle (BindableObject bindable, Style value)
			{
				bindable.SetValue (StyleProperty, value);
			}
        }
    }
