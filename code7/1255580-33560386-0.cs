     class X
     {
          public int GetX(){ return 1;}
          public int GetX(string s){ return 2;}
     }
	var r =  typeof(X).GetMember("GetX", MemberTypes.Method, 
            BindingFlags.Instance|BindingFlags.Public); // 2 items
