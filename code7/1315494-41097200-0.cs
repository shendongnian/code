    using UnityEngine;
    using UnityEditor;
    
    namespace MyProjectNamespace
    {
    	[ CustomEditor( typeof( MyMonoBehaviour ) ) ]
    
    	[ CanEditMultipleObjects ]
    	
    	public class MyMonoBehaviourInspector : Editor
    	{
    		#region Variables
    		
    		SerializedProperty _myBoolSP;
    
    		MyMonoBehaviour _myMonoBehaviour;
    		
    		#endregion Variables
    		
    		#region Functions
    		
    		void OnEnable()
    		{
    			
    			_myMonoBehaviour = serializedObject.targetObject as MyMonoBehaviour;
    			
    			_myBoolSP = serializedObject.FindProperty( "_myClass._myBool" );
    			
    			Debug.Log( "_myBoolSP = " + _myBoolSP.boolValue );
    			
    		}
    		
    		
    		
    		public override void OnInspectorGUI()
    		{
    			serializedObject.Update();
    			
    			_myBoolSP.boolValue = EditorGUILayout.Toggle( "A Boolean", _myBoolSP.boolValue );
    
    			GUILayout.Label( _myMonoBehaviour.MyBoolValue() );
    
    			serializedObject.ApplyModifiedProperties();
    		}
    		
    		#endregion Functions
    		
    	}
    	
    }
