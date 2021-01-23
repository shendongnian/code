    using UnityEngine;
    
    internal class Class1 : MonoBehaviour
    {
        public void Start()
        {
            var timeSpent = GetTimeSpent();
        }
    
        public void OnApplicationQuit()
        {
            SetTimeSpent(Time.realtimeSinceStartup);
        }
    
        private static float GetTimeSpent()
        {
            return PlayerPrefs.GetFloat("TimeSpent");
        }
    
        private static void SetTimeSpent(float timeSpent)
        {
            PlayerPrefs.SetFloat("TimeSpent", timeSpent);
            PlayerPrefs.Save();
        }
    }
