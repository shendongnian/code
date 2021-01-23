	public class InputVO
	{
		public bool isEnabled;
		public bool isValid;
		public InputType type;
		public object value;
		public int IntValue { get { return (int)value; } }
		public float FloatValue { get { return (float)value; } }
		public bool BoolValue { get { return (bool)value; } }
		public Vector2 Vector2Value { get { return (Vector2) value; } }
		public Vector3 Vector3Value { get { return (Vector3)value; } }
	}
