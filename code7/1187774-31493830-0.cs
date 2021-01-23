    using UnityEngine;
    using System.Collections;
    
    public class ToggleVisibility : MonoBehaviour 
    {
        public GameObject GameObjectToHide;
        public float MinTime = 2.0f;
        public float MaxTime = 5.0f;
    
        void Start()
        {
            StartCoroutine(ToggleVisibilityCo(GameObjectToHide));
        }
    
        IEnumerator ToggleVisibilityCo(GameObject someObj)
        {
            if (someObj == null) yield break;
    
            while(true)
            {
                someObj.SetActive(!someObj.active);
    
                yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
            }
    
        }
