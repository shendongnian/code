    var result = new GetServicePropertiesCommand().Invoke();
	var enumerator = result.GetEnumerator();
	enumerator.MoveNext();
	var props = (ServiceProperties) enumerator.Current;
	Console.WriteLine(props.SsoLifetime);
    // OR using a ForEach loop to enumerate
	//foreach (var item in result)
	//{
	//	var props = (ServiceProperties) item;
	//	Console.WriteLine(props.SsoLifetime);
	//}
