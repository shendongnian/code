    using UnityEngine;
    using System.Collections;
    
    public class Main : MonoBehaviour
    {
    
        // Use this for initialization
        void Start()
        {
            Mesh holderMesh = new Mesh();
            ObjImporter newMesh = new ObjImporter();
            holderMesh = newMesh.ImportFile("C:/Users/cvpa2/Desktop/ng/output.obj");
    
            MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
            MeshFilter filter = gameObject.AddComponent<MeshFilter>();
            filter.mesh = holderMesh;
        }
    }
