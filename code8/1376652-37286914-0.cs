    using UnityEditor;
    using UnityEngine;
    
    class SomeComponent : MonoBehaviour
    {
    	public MyScriptable myScriptable;
    }
    
    class MyScriptable : ScriptableObject
    {
    	public float myChildValue = 0.1f;
    }
    
    [CustomEditor(typeof(SomeComponent))]
    class SomeComponentEditor : Editor
    {
    	public override void OnInspectorGUI()
    	{
    		SomeComponent someComponent = target as SomeComponent;
    		if (someComponent.myScriptable == null)
    			someComponent.myScriptable = CreateInstance<MyScriptable>();
    
    		SerializedProperty myScriptableProp = serializedObject.FindProperty("myScriptable");
    		EditorGUILayout.PropertyField(myScriptableProp);
    
    		SerializedObject child = new SerializedObject(myScriptableProp.objectReferenceValue);
    		SerializedProperty myChildValueProp = child.FindProperty("myChildValue");
    		EditorGUILayout.PropertyField(myChildValueProp);
		    child.ApplyModifiedProperties();
    	}
    }
