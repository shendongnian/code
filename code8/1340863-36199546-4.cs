     public static string input(object class_name){
			if (class_name != null)
			{
				Foo newObj = Activator.CreateInstance(class_name.GetType());
				newObj.menu();
			}
     }
