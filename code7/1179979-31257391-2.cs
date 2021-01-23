     struct MyBoolWrapper 
     {
         public bool Value { get; set; }
     }
     public SomeClass(ref MyBoolWrapper value)
     {
		 value = this.value;
     }
      
     public void OnNext(object someUpdatedValue)
	 {
		value.Value = true;
	 }
