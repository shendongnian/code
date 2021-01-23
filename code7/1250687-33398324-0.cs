	public Transform stuckTo;
	public Vector3 offset = Vector3.zero;
	public void LateUpdate()
	{
		if (stuckTo != null)
			transform.position = stuckTo.position + offset;
	}
	void OnCollisionEnter(Collision col)
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		stuckTo = col.gameObject.transform;
		offset = col.gameObject.transform - transform.position;
	}
