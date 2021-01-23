    public MeshRenderer _meshRenderer;
	public float _moveXDirection;
	public Rigidbody _rigidBody;
	public Transform _meshTransform;
	public bool _sticksToObjects;
	public ScalingScript _scalingScript;
	
	protected Transform _stuckTo = null;
	protected Vector3 _offset = Vector3.zero;
	
	void LateUpdate() 
	{
		if (_stuckTo != null)
		{
			transform.position = _stuckTo.position - _offset;
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (!_sticksToObjects) {
			return;
		}
		
		_rigidBody.isKinematic = true;
		
		// Get the approximate collision point and normal, as there
		// may be multipled collision points
		Vector3 contactPoint = Vector3.zero;
		Vector3 contactNormal = Vector3.zero;
		for (int i = 0; i < collision.contacts.Length; i++) 
		{
			contactPoint += collision.contacts[i].point;
			contactNormal += collision.contacts[i].normal;
		}
		
		// Get the final, approximate, point and normal of collision
		contactPoint /= collision.contacts.Length;
		contactNormal /= collision.contacts.Length;
		
		// Move object to the collision point
		// This acts as setting the pivot point of the cube mesh to the collision point
		transform.position = contactPoint;
		
		// Adjust the local position of the cube so it is flush with the pivot point
		Vector3 meshLocalPosition = Vector3.zero;
		// Move the child so the side is at the collision point.
		// A x local position of 0 means the child is centered on the parent,
		// a value of 0.5 means it's to the right, and a value of -0.5 means it to the left
		meshLocalPosition.x = (0.5f * contactNormal.x);
		_meshTransform.localPosition = meshLocalPosition;
		if (_stuckTo == null || _stuckTo != collision.gameObject.transform) 
		{
			_offset = collision.gameObject.transform.position - transform.position;
		}
		
		_stuckTo = collision.gameObject.transform;
		// Enable the scaling script
		if (_scalingScript != null)
		{
			_scalingScript.enabled = true;
		}
	}
