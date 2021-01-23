    #if UNITY_EDITOR
    using UnityEngine;
    using System.Collections;
    
    /// <summary>
    /// http://answers.unity3d.com/questions/14567/editing-mesh-vertices-in-unity.html
    /// </summary>
    [AddComponentMenu("Mesh/Vert Handler")]
    [ExecuteInEditMode]
    public class EditMesh : MonoBehaviour {
    
        public bool _destroy;
    
        private Mesh mesh;
        private Vector3[] verts;
        private Vector3 vertPos;
        private GameObject[] handles;
    
        private const string TAG_HANDLE = "editMesh";
    
        void OnEnable() {
            mesh = GetComponent<MeshFilter>().sharedMesh; // sharedMesh seem equivalent to .mesh
            verts = mesh.vertices;
            foreach (Vector3 vert in verts) {
                vertPos = transform.TransformPoint(vert);
                GameObject handle = new GameObject(TAG_HANDLE);
                //         handle.hideFlags = HideFlags.DontSave;
                handle.transform.position = vertPos;
                handle.transform.parent = transform;
                handle.tag = TAG_HANDLE;
                handle.AddComponent<EditMeshGizmo>()._parent = this;
    
            }
        }
    
        void OnDisable() {
            GameObject[] handles = GameObject.FindGameObjectsWithTag(TAG_HANDLE);
            foreach (GameObject handle in handles) {
                DestroyImmediate(handle);
            }
        }
    
        void Update() {
            if (_destroy) {
                _destroy = false;
                DestroyImmediate(this);
                return;
            }
    
            handles = GameObject.FindGameObjectsWithTag(TAG_HANDLE);
    
            for (int i = 0; i < verts.Length; i++) {
                verts[i] = handles[i].transform.localPosition;
            }
    
            mesh.vertices = verts;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
    
    
        }
    
    }
    
    #endif
