    using UnityEngine;
    using System.Collections;
    
    public class Test : MonoBehaviour
    {
        bool loadingStarted = false;
        float secondsLeft = 0;
    
        void Start()
        {
            StartCoroutine(DelayLoadLevel(10));
        }
    
        IEnumerator DelayLoadLevel(float seconds)
        {
            secondsLeft = seconds;
            loadingStarted = true;
            do
            {
                yield return new WaitForSeconds(1);
            } while (--secondsLeft > 0);
    
            Application.LoadLevel("Level2");
        }
    
        void OnGUI()
        {
            if (loadingStarted)
                GUI.Label(new Rect(0, 0, 100, 20), secondsLeft.ToString());
        }
    }
