    class MyBehaviour: public MonoBehaviour {
        void Start() {
            StartCoroutine(GetText());
        }
     
        IEnumerator GetText() {
            UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com");
            yield return www.Send();
     
            if(www.isError) {
                Debug.Log(www.error);
            }
            else {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
     
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
        // Edit here
        StartCoroutine(GetText());
    }
