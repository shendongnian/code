    using System;
    using UnityEngine;
    using Random = UnityEngine.Random;
    
    [ExecuteInEditMode]
    public class SphereBuilder : MonoBehaviour
    {
        // for tracking properties change
        private Vector3 _extents;
        private int _sphereCount;
        private float _sphereSize;
    
        /// <summary>
        ///     How far to place spheres randomly.
        /// </summary>
        public Vector3 Extents;
    
        /// <summary>
        ///     How many spheres wanted.
        /// </summary>
        public int SphereCount;
    
        public float SphereSize;
    
        private void OnValidate()
        {
            // prevent wrong values to be entered
            Extents = new Vector3(Mathf.Max(0.0f, Extents.x), Mathf.Max(0.0f, Extents.y), Mathf.Max(0.0f, Extents.z));
            SphereCount = Mathf.Max(0, SphereCount);
            SphereSize = Mathf.Max(0.0f, SphereSize);
        }
    
        private void Reset()
        {
            Extents = new Vector3(250.0f, 20.0f, 250.0f);
            SphereCount = 100;
            SphereSize = 20.0f;
        }
    
        private void Update()
        {
            UpdateSpheres();
        }
    
        private void UpdateSpheres()
        {
            if (Extents == _extents && SphereCount == _sphereCount && Mathf.Approximately(SphereSize, _sphereSize))
                return;
    
            // cleanup
            var spheres = GameObject.FindGameObjectsWithTag("Sphere");
            foreach (var t in spheres)
            {
                if (Application.isEditor)
                {
                    DestroyImmediate(t);
                }
                else
                {
                    Destroy(t);
                }
            }
    
            var withTag = GameObject.FindWithTag("Terrain");
            if (withTag == null)
                throw new InvalidOperationException("Terrain not found");
    
            for (var i = 0; i < SphereCount; i++)
            {
                var o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                o.tag = "Sphere";
                o.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);
    
                // get random position
                var x = Random.Range(-Extents.x, Extents.x);
                var y = Extents.y; // sphere altitude relative to terrain below
                var z = Random.Range(-Extents.z, Extents.z);
    
                // now send a ray down terrain to adjust Y according terrain below
                var height = 10000.0f; // should be higher than highest terrain altitude
                var origin = new Vector3(x, height, z);
                var ray = new Ray(origin, Vector3.down);
                RaycastHit hit;
                var maxDistance = 20000.0f;
                var nameToLayer = LayerMask.NameToLayer("Terrain");
                var layerMask = 1 << nameToLayer;
                if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
                {
                    var distance = hit.distance;
                    y = height - distance + y; // adjust
                }
                else
                {
                    Debug.LogWarning("Terrain not hit, using default height !");
                }
    
                // place !
                o.transform.position = new Vector3(x, y, z);
            }
    
            _extents = Extents;
            _sphereCount = SphereCount;
            _sphereSize = SphereSize;
        }
    }
