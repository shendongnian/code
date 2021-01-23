     public static string input(object class_name){
            if (class_name as Foo != null)
			{
				((Foo)class_name).menu();
			}
     }
