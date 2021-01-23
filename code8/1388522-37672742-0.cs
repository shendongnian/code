    using UnityEngine;
    using System.Collections;
    
    public class PostJsonDataScript : MonoBehaviour
    {
        // Use this for initialization
        string Url;
        void Start()
        {
            Url = "Url to the service";
            PostData(100,"Unity");
        }
        // Update is called once per frame
        void Update()
        {
    
        }
        void PostData(int Id,string Name)
        {
            WWWForm dataParameters = new WWWForm();
            dataParameters.AddField("Id", Id);
            dataParameters.AddField("Name", Name);
            WWW www = new WWW(Url,dataParameters);
            StartCoroutine("PostdataEnumerator", Url);
        }
        IEnumerator PostdataEnumerator(WWW www)
        {
            yield return www;
            if (www.error != null)
            {
                Debug.Log("Data Submitted");
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
