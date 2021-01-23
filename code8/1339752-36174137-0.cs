    using UnityEngine;
    // adding ExecuteInEditMode attribute so we can easily see the results from the editor
    [RequireComponent(typeof(MeshFilter))]
    [ExecuteInEditMode]
    public class VertexChanger : MonoBehaviour {
        // assign these from the editor
        public Transform Sphere0;
        public Transform Sphere1;
        public Transform Sphere2;
        public Transform Sphere3;
        // doing changes in update so we see this immediately from the editor
        void Update () {
            if (Sphere0 == null || Sphere1 == null || Sphere2 == null || Sphere3 == null) {
                return;
            } 
            // create a new array of vertices and assign it
            Vector3[] newVertices = new[] {
                Sphere0.transform.position,
                Sphere1.transform.position,
                Sphere2.transform.position,
                Sphere3.transform.position
            };
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            meshFilter.sharedMesh.vertices = newVertices;
            // these calls are not strictly necessary here...
            meshFilter.mesh.RecalculateBounds();
            meshFilter.mesh.RecalculateNormals();
        }
    }
