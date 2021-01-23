    Color TraceRay(Ray ray, Color color, int recursiveLevel)
    {
        if (recursiveLevel < maxRecursion)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDist))
            {
                Vector3 viewVector = ray.direction;
                Vector3 pos = hit.point + hit.normal * 0.0001f;
                Vector3 normal = hit.normal;
                RayTracerObject rto = hit.collider.gameObject.GetComponent<RayTracerObject>();
                //Does the object we hit have that script? 
                if(rto == null) 
                {
                     var GO = hit.collider.gameObject;
                     Debug.Log("Raycast hit failure! On " + GO.name + " position " + GO.transform.position.ToString());
                     return color; //exit out
                }
