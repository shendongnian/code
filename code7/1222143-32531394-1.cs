    async void Main() {
    	Test t = new Test();
    	Type type = typeof(Test);
    
    	await t.TryUpdate(type.GetProperty(nameof(t.Name)), "asdf");
    	await t.TryUpdate(type.GetProperty(nameof(t.Number)), "A1B2");
    	await t.TryUpdate(type.GetProperty(nameof(t.Object)), (object)new ComplexObject());
    
    	Console.WriteLine(t.ToString());
    }
    
    public class Test {
    	public string Name { get; set; }
    	public string Number { get; set; }
    	public IComplexObject Object { get; set; }
    
    	// Added for the purpose if showing contents
    	public override string ToString() => $"Name: {Name}, Number: {Number}, Object: {Object}";
    
    	// Why is this async?  Your code does not await
    	public async Task<bool> TryUpdate(PropertyInfo prop, object value) {
    		await Task.Delay(0); // Added to satisfy async
    		try {
    			prop.SetValue(this, value);
    
    			// If not set probably a complex type
    			if (value != prop.GetValue(this)) {
    				//... Don't know what to do
    			}
    
    			return true;
    		}
    		catch {
    			return false;
    		}
    	}
    
    }
    
    public interface IComplexObject { }
    class ComplexObject : IComplexObject {
    	public override string ToString() => "hello this is complexobject";
    }
