    public class KeyboardStyle
    	{
    		public static BindableProperty KeyboardFlagsProperty = BindableProperty.CreateAttached(
    			propertyName: "KeyboardFlags",
    			returnType: typeof(string),
    			declaringType: typeof(InputView),
    			defaultValue: null,
    			defaultBindingMode: BindingMode.OneWay,
    			propertyChanged: HandleKeyboardFlagsChanged);
    
    		public static void HandleKeyboardFlagsChanged(BindableObject obj, object oldValue, object newValue)
    		{
    			var entry = obj as InputView;
    
    			if(entry == null)
    			{
    				return;
    			}
    
    			if(newValue == null)
    			{
    				return;
    			}
    
    			string[] flagNames = ((string)newValue).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    			KeyboardFlags allFlags = 0;
    
    			foreach (var flagName in flagNames) {
    				KeyboardFlags flags = 0;
    				Enum.TryParse<KeyboardFlags>(flagName.Trim(), out flags);
    				if(flags != 0)
    				{
    					allFlags |= flags;		
    				}
    			}
    
    			Debug.WriteLine("Setting keyboard to: " + allFlags);
    			var keyboard = Keyboard.Create(allFlags);
    
    			entry.Keyboard = keyboard;
    		}
    	}
