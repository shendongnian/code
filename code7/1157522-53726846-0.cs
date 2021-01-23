    public static IEnumerable<Action<object>> Registrations(this CancellationToken token)
    {
     		var sourceFieldInfo = typeof(CancellationToken).GetField("m_source", BindingFlags.NonPublic | BindingFlags.Instance);
        
   			var cancellationTokenSource = (CancellationTokenSource)sourceFieldInfo.GetValue(token);
        
        	var callbacksFieldInfo = typeof(CancellationTokenSource).GetField("m_registeredCallbacksLists", BindingFlags.NonPublic | BindingFlags.Instance);
        
        	var callbaskLists = (Array)callbacksFieldInfo.GetValue(cancellationTokenSource);
        
        	foreach (var sparselyPopulatedArray in callbaskLists)
        	{
        		if (sparselyPopulatedArray == null)
        		{
        			continue;
        		}
        
        		var sparselyPopulatedArrayType = sparselyPopulatedArray.GetType();
        
        		var tailFieldInfo = sparselyPopulatedArrayType.GetProperty("Tail", BindingFlags.NonPublic | BindingFlags.Instance);
        
        		var tail = tailFieldInfo.GetValue(sparselyPopulatedArray);
        
        		var sparselyPopulatedArrayFragmentType = tail.GetType();
        
        		var elementsTypeFieldInfo = sparselyPopulatedArrayFragmentType.GetField("m_elements", BindingFlags.NonPublic | BindingFlags.Instance);
        
        		var elements = (Array)elementsTypeFieldInfo.GetValue(tail);
        
        		foreach (var callbackInfo in elements)
        		{
        			if (callbackInfo == null)
        			{
        				continue;
        			}
        			var callbackInfoType = callbackInfo.GetType();
        
        			var callbackFieldInfo = callbackInfoType.GetField("Callback", BindingFlags.NonPublic | BindingFlags.Instance);
        
        			var callback = (Action<object>)callbackFieldInfo.GetValue(callbackInfo);
        
        			if (callback != null)
        			{
        				yield return callback;
        			}
        		}
       		}
   		}
