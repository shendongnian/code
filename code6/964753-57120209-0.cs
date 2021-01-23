    using UnityEngine;
    using System.Collections;
    using UnityEngine.Networking;
     
    public class MyBehaviour : MonoBehaviour {
        void Start() {
            StartCoroutine(GetText());
        }
     
        IEnumerator GetText() {
            UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com");
            yield return www.SendWebRequest();
     
            if(www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            }
            else {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
     
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }
