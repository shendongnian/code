    using UnityEngine;
    using System.Collections;
    public class AssetBundleAugmenter : MonoBehaviour {
    	public string AssetName;
    	public int Version;
    	
    	private GameObject mBundleInstance = null;
    	
    	void Start() {  
    		StartCoroutine(DownloadAndCache());
    		}
    	// Update is called once per frame
    	IEnumerator DownloadAndCache() {
    		while(!Caching.ready)
    			yield return null;
    		
    		// example URL of file on PC filesystem (Windows)
    		// string bundleURL = "file:///D:/Unity/AssetBundles/MyAssetBundle.unity3d";
    		
    		// example URL of file on Android device SD-card
    		string bundleURL = "file:///mnt/sdcard/AndroidCube.unity3d";
    		
    		using (WWW www = WWW .LoadFromCacheOrDownload(bundleURL, Version)) {
    			yield return www;
    			
    			if (www .error != null)
    				throw new UnityException("WWW Download had an error: " + www .error);
    			// Load and retrieve the AssetBundle
    			AssetBundle bundle = www .assetBundle;
    			// Load the assembly and get a type (class) from it
    			var assembly = System.Reflection.Assembly.Load("txt.bytes");
    			var type = assembly.GetType("MyClassDerivedFromMonoBehaviour");
    			// Instantiate a GameObject and add a component with the loaded class
    			GameObject go = new GameObject();
    			go.AddComponent(type);
    			if (AssetName == "") {
    				mBundleInstance = Instantiate (bundle.mainAsset) as GameObject;
    			}
    			else {
    				mBundleInstance = Instantiate(bundle.LoadAsset (AssetName)) as GameObject;
    			}
    		
    	
    			// Unload the AssetBundles compressed contents to conserve memory
    			bundle.Unload(false);
    		}
    	}
    	
    }
