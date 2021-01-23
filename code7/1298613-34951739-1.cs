    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using System.Web;
    
    namespace SomeNamespace {
    public class NameObjectCollectionBaseConverter {
    	public static Dictionary<string, string> Convert(NameValueCollection coll) {
    		var keyValues = new Dictionary<string, string>();
    		var keys = coll.Keys;
    		foreach(var key in keys) {
    			var strKey = key.ToString();
    			var value = coll.Get(strKey).ToString();
    			keyValues.Add(strKey, value);
    		}
    
    		return keyValues;
    	}
    		public static Dictionary<string, string> Convert(WebHeaderCollection coll) {
    		var keyValues = new Dictionary<string, string>();
    		var keys = coll.Keys;
    		foreach(var key in keys) {
    			var strKey = key.ToString();
    			var value = coll.Get(strKey).ToString();
    			keyValues.Add(strKey, value);
    		}
    
    		return keyValues;
    	}
    		public static Dictionary<string, string> Convert(HttpApplicationStateBase coll) {
    		var keyValues = new Dictionary<string, string>();
    		var keys = coll.Keys;
    		foreach(var key in keys) {
    			var strKey = key.ToString();
    			var value = coll.Get(strKey).ToString();
    			keyValues.Add(strKey, value);
    		}
    
    		return keyValues;
    	}
    		public static Dictionary<string, string> Convert(HttpApplicationStateWrapper coll) {
    		var keyValues = new Dictionary<string, string>();
    		var keys = coll.Keys;
    		foreach(var key in keys) {
    			var strKey = key.ToString();
    			var value = coll.Get(strKey).ToString();
    			keyValues.Add(strKey, value);
    		}
    
    		return keyValues;
    	}
    		public static Dictionary<string, string> Convert(HttpApplicationState coll) {
    		var keyValues = new Dictionary<string, string>();
    		var keys = coll.Keys;
    		foreach(var key in keys) {
    			var strKey = key.ToString();
    			var value = coll.Get(strKey).ToString();
    			keyValues.Add(strKey, value);
    		}
    
    		return keyValues;
    	}
    		public static Dictionary<string, string> Convert(HttpClientCertificate coll) {
    		var keyValues = new Dictionary<string, string>();
    		var keys = coll.Keys;
    		foreach(var key in keys) {
    			var strKey = key.ToString();
    			var value = coll.Get(strKey).ToString();
    			keyValues.Add(strKey, value);
    		}
    
    		return keyValues;
    	}
    		
    }
    }
