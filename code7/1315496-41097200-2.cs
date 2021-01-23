    using UnityEngine;
    
    namespace MyProjectNamespace
    {
    	[ System.Serializable ]
    	
    	public class MyClass
    	{
    		#region Variables
    		
    		[ SerializeField ] private bool _myBool;
    		
    		#endregion Variables
    		
    		#region Functions
    		
    		public bool MyBool
    		{
    			get{ return _myBool; }
    		}
    		
    		#endregion Functions
    		
    	}
    	
    }
