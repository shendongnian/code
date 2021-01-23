    [CustomPropertyDrawer(typeof(BaseDamage))]
    public class BaseDamageDrawer : PropertyDrawer
    {
	static string[] propNames = new[]
	{
		"MaximumDamage",
		"MinimumDamage",
		"SpellScaling",
	};
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);
		// Draw label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		// Don't make child fields be indented
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		SerializedProperty[] props = new SerializedProperty[propNames.Length];
		for (int i = 0; i < props.Length; i++)
		{
			props[i] = property.FindPropertyRelative(propNames[i]);
		}
		// Calculate rects
		float x = position.x;
		float y = position.y;
		float w = position.width / props.Length;
		float h = position.height;
		for (int i = 0; i < props.Length; i++)
		{
			var rect = new Rect(x, y, w, h);
			EditorGUI.PropertyField(rect, props[i], GUIContent.none);
			x += position.width / props.Length;
		}
		// Set indent back to what it was
		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
    }
