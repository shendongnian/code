    public void Store(Object source){
		var thisType = this.GetType ();
		var sourceFields = source.GetType ().GetFields (flags);
		foreach (var field in sourceFields) { //get all properties via reflection
			var instanceField = thisType.GetField (field.Name);
			if(instanceField != null){ //check if this instance has the source's property
				var value = field.GetValue(source); //get the value from the object
				if(value != null){
					instanceField.SetValue(this, value); //put it into this instance
				}
			}
		}
	}
	public T LoadIntoObject<T> (T target){
		var targetFields = target.GetType().GetFields ();
		foreach (var field in targetFields) {
			var instanceField = this.GetType().GetField (field.Name);
			if(instanceField != null){ //check if this instance has the targets's property
				var value = instanceField.GetValue(this);
				if(value != null){
					field.SetValue(target, value); //put it into the target
				}
			}
		}
		return target;
	}
