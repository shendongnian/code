    if (Hit.Length > 0)
    {
        float firstHitDistance = 100000f; //or something ridiculously high
        RaycastHit firstHit;
        for (int x = 0; x < Hit.Length; x++)
        {
            if(Hit[x].distance < firstHitDistance){
                firstHitDistance = Hit[x].distance;
                firstHit = Hit[x];
            }
        }
                    
                    if (firstHit.collider.tag  == "Mirror" || !firstHit.collider.isTrigger)
                    {
                        Debug.DrawLine(s, firstHit.point, Color.blue);
                        lr.SetPosition(1, firstHit.point);
                       // Debug.Log("loop W" + x);
                        if (firstHit.collider.tag == "Mirror") Reflect(s, , 0);
                        else lr.SetVertexCount(2);
                        break; 
                    }
    }
