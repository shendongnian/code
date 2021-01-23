    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class TestScriptableEditorWindow : EditorWindow {
    	public static TestScriptableEditorWindow testScriptableEditorWindow;
    	private TestScriptable testScriptable;
    	[MenuItem("Window/TestTaskIceCat/TestScriptableEditor")]
    	public static void Init() {
    		// initialize window, show it, set the properties
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
    		}
    	}
    	public void OnGUI() {
    		if (testScriptable == null) {
    			/* certain actions if my asset is null */
    			return;
    		}
    		testScriptable.gravity = EditorGUILayout.FloatField("Gravity:", testScriptable.gravity);
    		testScriptable.plinkingDelay = EditorGUILayout.FloatField("Plinking Delay:", testScriptable.plinkingDelay);
    		testScriptable.storedExecutionDelay = EditorGUILayout.FloatField("Stored Execution Delay:", testScriptable.storedExecutionDelay);
    		
    		// Magic of the data saving
    		if (GUI.changed) {
    			// writing changes of the testScriptable into Undo
    			Undo.RecordObject(testScriptable, "Test Scriptable Editor Modify");
    			// mark the testScriptable object as "dirty" and save it
    			EditorUtility.SetDirty(testScriptable); 
    		}
    	}    
    		
    	void OnSelectionChange() { Populate(); Repaint(); }
    	void OnEnable() { Populate(); }
    	void OnFocus() { Populate(); }
    }
