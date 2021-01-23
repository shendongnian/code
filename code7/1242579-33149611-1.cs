    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    [ExecuteInEditMode]
    public class tester : MonoBehaviour
    {
        public Transform PairedTransform;
        void Update()
        {
            if (!Selection.Contains(gameObject))
            {
                gameObject.transform.localScale = PairedTransform.localScale;
            }
        }
    }
