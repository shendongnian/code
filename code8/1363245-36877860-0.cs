    using UnityEngine;
    using System.Collections;
    public class ExampleClass : MonoBehaviour {
        public Vector3[] newVertices;
        public Vector2[] newUV;
        public int[] newTriangles;
        void Start() {
            Mesh mesh = new Mesh();
            mesh.vertices = newVertices;
            mesh.uv = newUV;
            mesh.triangles = newTriangles;
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }
