    public class MyServiceBase : Service
	{
		public T GetInstance<T>(string typeName, object value)
		{
			// Get the customer name from the request items
			var customer = Request.GetItem("customer") as string;
			if(customer == null) throw new Exception("Customer has not been set");
			// Create the typeof the object from the customer name and the type format
			var type = Type.GetType(string.Format(typeName, customer));
			// Create an instance of the type
			var instance = Activator.CreateInstance(type) as T;
			// Check the instance is valid
			if(instance == default(T)) throw new Exception("Unable to create instance");
			// Populate it with the values from the request
			instance.PopulateWith(value);
			// Return the instance
			return instance;
		}
	}
