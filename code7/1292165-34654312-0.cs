    Vector3 previous;
    int vertexCount = 0;
    List<Vector3>positions;
    void Update(){
        if(Input.detected){
           Vector3 current = Input.position; 
           if(Vector3.Distance(previous, current) < threshold){ return; }
           SetVertexCount(++vertexCount);
           positions.Add(current);
           for (int i= 0; i < vertexCount; i++)
           {
               lineRenderer.SetPosition(i, positions[i].transform.position);
           }
       }
    }
