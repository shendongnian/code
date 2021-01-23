    public float _moveXDirection;
    public MeshRenderer _childMeshRenderer;
	public Rigidbody _rigidBody;
	public Transform _childTransform;
	public bool _sticksToObjects;
	
	protected Transform _stuckTo = null;
	protected Vector3 _offset = Vector3.zero;
	
	
	void OnCollisionEnter(Collision collision)
	{	
		_rigidBody.isKinematic = true;
		
		// Get the approximate collision point and normal, as there
		// may be multiplied collision points
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
		// This acts as setting the pivot point of the child gameobject to the collision point
		transform.position = contactPoint;
		
		// Adjust the local position of the gameobject so it is flush with the pivot point
		Vector3 childLocalPos = Vector3.zero;
		childLocalPos.x = _childMeshRenderer.bounds.extents.x * contactNormal.x;
		_childTransform.localPosition = childLocalPos;
		
		if (_stuckTo == null || _stuckTo != collision.gameObject.transform) 
		{
			_offset = collision.gameObject.transform.position - transform.position;
		}
		
		_stuckTo = collision.gameObject.transform;
	}
