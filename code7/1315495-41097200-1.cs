    using UnityEngine;
    
    namespace MyProjectNamespace
    {
    	public class MyMonoBehaviour : MonoBehaviour
    	{
    		#region Variables
    		
    		[ SerializeField ] private MyClass _myClass;
    		
    		#endregion Variables
    		
    		#region Functions
    		
    		public string MyBoolValue()
    		{
    			return "The value of _myBool is " + _myClass.MyBool;
    		}
    		
    		#endregion Functions
    		
    	}
    	
    }
