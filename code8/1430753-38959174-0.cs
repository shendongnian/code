	//  c# script
	void OnCollisionEnter2D(Collision2D collision) {
		foo(collision);
	}
	void OnTriggerEnter2D(Collider2D collider) {
		foo(collider);
	}
	void foo(Collision2D coll){
		//checking inside here
	}
	void foo(Collider2D coll){
		
	}
