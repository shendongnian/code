    protected Transform stuckTo = null;
    protected Vector3 originalPositionOffset = Vector3.zero;
    protected Vector3 positionOffset = Vector3.zero;
    protected Vector3 originalScaleOfTheTarget = Vector3.zero;
    
    public void LateUpdate()
    {
        if (stuckTo != null){
            positionOffset *= stuckTo.localScale.x;
            transform.position = stuckTo.position - positionOffset;
        }
    }  
    
    void OnCollisionEnter(Collision col)
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    
        if(stuckTo == null 
           || stuckTo != col.gameObject.transform){
            originalScaleOfTheTarget = col.gameObject.transform.localScale;
            originalPositionOffset = col.gameObject.transform.position - transform.position;
            originalPositionOffset /= originalScaleOfTheTarget.x;
        }
    
        stuckTo = col.gameObject.transform;
    }
