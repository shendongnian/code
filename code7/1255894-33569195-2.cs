	public string cn{
		get {return courseNumber; }
		set {if (value != null)
			courseNumber = value;
		}
	}
	public string name{
		get { return courseName; }
		set
		{
			if (value != "")
				courseName = value;
		}
	}
	public int hours{
		get {return courseHours; }
		set {if (value != 0)
			courseHours = value;
		}
	}
