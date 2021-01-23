    [Serializable]
    public abstract class Generic { }
    [Serializable]
    public abstract class Generic<T> : Generic {
        public T value;
    }
    [Serializable]
    public class GenericInt : Generic<int> { }
    [Serializable]
    public class GenericFloat : Generic<float> { }
    [CustomPropertyDrawer (typeof (Generic), true)]
    public class IngredientDrawer : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty (position, label, property);
            position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
            EditorGUI.PropertyField (position, property.FindPropertyRelative ("value"), GUIContent.none);
            EditorGUI.EndProperty ();
        }
    }
