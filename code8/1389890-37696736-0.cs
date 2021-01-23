    using Foundation;
    using ObjCRuntime;
    
    namespace Sushi.Sensoro.BeaconKit
    {
    
    	public class ConstantsEx
    	{
    		static NSUuid _SBKSensoroDefaultProximityUUID;
    		static public NSUuid SBKSensoroDefaultProximityUUID
    		{
    			get
    			{
    				if (_SBKSensoroDefaultProximityUUID == null)
    				{
    					var libUUID = Runtime.GetNSObject(Constants.SBKSensoroDefaultProximityUUID) as NSUuid;
    					_SBKSensoroDefaultProximityUUID = new NSUuid(libUUID.GetBytes());
    				}
    				return _SBKSensoroDefaultProximityUUID;
    			}
    		}
    	}
    }
