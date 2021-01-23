    List<String> formList = new List<String>();
    Assembly myAssembly = Assembly.GetExecutingAssembly();
    
    foreach (Type t in myAssembly.GetTypes())
    {
    	if (t.BaseType == typeof(Form))
    	{
    		ConstructorInfo ctor = t.GetConstructor(Type.EmptyTypes);
    		if (ctor != null)
    		{
    			Form f = (Form)ctor.Invoke(new object[] { });
    			formList.Add("Text: " +  f.Text + ";Name: " + f.Name);
    		}
    	}
    }
