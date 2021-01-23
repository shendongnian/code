    #if UNITY_EDITOR
    using UnityEngine;
    using System.Collections;
    
    /// <summary>
    /// http://answers.unity3d.com/questions/14567/editing-mesh-vertices-in-unity.html
    /// </summary>
    [ExecuteInEditMode]
    public class EditMeshGizmo : MonoBehaviour {
    
        private static float CURRENT_SIZE = 0.1f;
        
        public float _size = CURRENT_SIZE;
        public EditMesh _parent;
        public bool _destroy;
    
        private float _lastKnownSize = CURRENT_SIZE;
    
        void Update() {
            // Change the size if the user requests it
            if (_lastKnownSize != _size) {
                _lastKnownSize = _size;
                CURRENT_SIZE = _size;
            }
    
            // Ensure the rest of the gizmos know the size has changed...
            if (CURRENT_SIZE != _lastKnownSize) {
                _lastKnownSize = CURRENT_SIZE;
                _size = _lastKnownSize;
            }
    
            if (_destroy)
                DestroyImmediate(_parent);
        }
    
        void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, Vector3.one * CURRENT_SIZE);
        }
    
    }
    #endif
