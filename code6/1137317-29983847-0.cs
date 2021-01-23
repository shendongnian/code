    using UnityEngine;
    using System.Collections;
    
    /// <summary>
    /// Saving and loading data to a persistent data path
    /// </summary>
    public class LoadSaveCheck : MonoBehaviour {
    
    	public static void Save(string name, byte[] bytes) {
    		var path=System.IO.Path.Combine(Application.persistentDataPath, name);
    		System.IO.File.WriteAllBytes (path, bytes);
    	}
    
    	public static byte[] Load(string name) {
    		var path=System.IO.Path.Combine(Application.persistentDataPath, name);
    		return System.IO.File.ReadAllBytes (path);
    	}
    
    
    	/// <summary>
    	/// Test - writing and reading a text file. Should work with any byte stream (like the one from Texture2D.EncodeToPNG)
    	/// </summary>
    	void Start() {
    		Debug.Log ("Application.persistentDataPath=" + Application.persistentDataPath, this);
    
    		Debug.Log ("saving...", this);
    		var bytes = System.Text.Encoding.UTF8.GetBytes ("test test test");
    		Save ("test.txt", bytes);
    
    		Debug.Log ("loading...", this);
    		var loadedBytes = Load ("test.txt");
    		var str=System.Text.Encoding.UTF8.GetString (loadedBytes);
    		Debug.Log ("got string: " + str, this);
    	}
    
    
    }
