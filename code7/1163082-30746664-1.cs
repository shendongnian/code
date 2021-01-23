    using UnityEngine;
    using System.Collections;
        public class MakeTriangle : MonoBehaviour {
        MeshFilter filter;
        MeshRenderer renderer;
        Mesh mesh;
        void Start(){
            filter = gameObject.AddComponent<MeshFilter>();
            renderer = gameObject.AddComponent<MeshRenderer>();
            mesh = filter.mesh;
            mesh.Clear();
            mesh.vertices = new Vector3[] {new Vector3(0,0,0), new Vector3(0,1,0), new Vector3(1,1,0)};
            mesh.uv = new Vector2[] {new Vector2(0,0), new Vector2(0,1), new Vector2(1,1)};
            mesh.triangles = new int[] {0,1,2};
        }
    }
