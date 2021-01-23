    private void ProcessFile(string xFile) {
            // ...
            // ...
			// Determine List Type
			System.Type listType = typeof(List<>).MakeGenericType(entityType);
			if(listType == null) return;    
			
			// Acquire Data
			streamReader = File.OpenText(xFile);
			object data = null;
			data = System.Activator.CreateInstance(listType);        
			data = serialiser.Deserialize(streamReader, listType);
			if(data == null) return;
			
			// Store Data in Game
			GameObject theGame = GameObject.FindGameObjectWithTag("Game");
			Component theComponent = theGame.GetComponent(manager);
			
			FieldInfo field = managerType.GetField(plural.ToLower());
			
			List<dynamic> theList = field.GetValue(theComponent) as List<dynamic>;
			field.SetValue(theComponent, data);
    }
