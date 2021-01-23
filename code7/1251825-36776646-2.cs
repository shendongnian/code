    // Load the assembly and get a type (class) from it
    			var assembly = System.Reflection.Assembly.Load("txt.bytes");
    			var type = assembly.GetType("MyClassDerivedFromMonoBehaviour");
    			// Instantiate a GameObject and add a component with the loaded class
    			GameObject go = new GameObject();
    			go.AddComponent(type);
