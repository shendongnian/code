	protected Transform stuckTo = null;
	protected Vector3 offset = Vector3.zero;
	public void LateUpdate()
	{
		if (stuckTo != null)
			transform.position = stuckTo.position - offset;
	}
	void OnCollisionEnter(Collision col)
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
        if(stuckTo == null 
            || stuckTo != col.gameObject.transform)
		    offset = col.gameObject.transform.position - transform.position;
		stuckTo = col.gameObject.transform;
	}
