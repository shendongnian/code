	//Lets assume that the original property that ranges from 0.1 to 0.9 is called MyProp
	public double MyPropBinding {
		get {
			return this.MyProp * 10.0;
		}
		set {
			this.MyProp = value / 10.0;
		}
	}
