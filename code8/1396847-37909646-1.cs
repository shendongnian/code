    public void onHover(Ray ray, RaycastHit2D hit)
    {
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit.collider == null)
        {
            Debug.Log("nothing hit");
        }            
        else
        {
            print(hit.collider.name);
        }
    }
