	using UnityEngine;
	using UnityEditor;
	public class TestScriptableEditorWindow : EditorWindow {
		public static TestScriptableEditorWindow testScriptableEditorWindow;
		private TestScriptable testScriptable;
		// declaring our serializable object, that we are working on
		private SerializedObject serializedObj;
		[MenuItem("Window/TestTaskIceCat/TestScriptableEditor")]
		public static void Init() {
			testScriptableEditorWindow = GetWindow<TestScriptableEditorWindow>(false, "TestScriptableEditorWindow", true);
			testScriptableEditorWindow.Show();
			testScriptableEditorWindow.Populate();
		}
        // initialization of troubled asset
		void Populate() {
			Object[] selection = Selection.GetFiltered(typeof(TestScriptable), SelectionMode.Assets);
			if (selection.Length > 0) {
				if (selection[0] == null)
					return;
				testScriptable = (TestScriptable)selection[0];
                // initialization of the serializedObj, that we are working on
				serializedObj = new SerializedObject(testScriptable);
			}
		}
		// our manipulation
		public void OnGUI() {
			if (testScriptable == null) {
				/* certain actions if my asset is null */
				return;
			}
			// Starting our manipulation
			// We're doing this before property rendering			
			serializedObj.Update();
			// Gets the property of our asset and скуфеу a field with its value
			EditorGUILayout.PropertyField(serializedObj.FindProperty("gravity"), new GUIContent("Gravity"), true);
			EditorGUILayout.PropertyField(serializedObj.FindProperty("plinkingDelay"), new GUIContent("Plinking Delay"), true);
			EditorGUILayout.PropertyField(serializedObj.FindProperty("storedExecutionDelay"), new GUIContent("Stored Execution Delay"), true);
			// Apply changes
			serializedObj.ApplyModifiedProperties();
		}
		void OnSelectionChange() { Populate(); Repaint(); }
		void OnEnable() { Populate(); }
		void OnFocus() { Populate(); }
	}
	
