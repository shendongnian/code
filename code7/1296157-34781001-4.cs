    public Transform greenCubeCenter;
    public float ThrowForceMagnitude = 50.0f;    
    Transform touchedObject = null; // this will hold the touched object
    
    void Update () {
        Collider2D touch = Physics2D.OverlapCircle(touchDetect.position, 0.01f, objectLayer);
        if(touch == null) // we don't do anything if we don't touch anything
            return;
        if (Input.GetKey(KeyCode.LeftShift)) { // let's do everything in one if
            ligado = true; // if the arm touch the cube we set ligado to true
            if(touchedObject == null) // we didn't have anything grabbed
            {
			    touchedObject = touch.gameObject.transform;
				touchedObject.parent = this.transform; // "glue" the object to the arm
				touchedObject.GetComponent<Rigidbody2D>().isKinematic = true; // forbid other forces to move our object
				Physics2D.IgnoreLayerCollision(10, 12, true); // I let this thing here, don't really know what it does in this context
            }
        } else {
            ligado = false; // in any case we're not in "grab mode" anymore so let's set ligado to false
			
			if(touchedObject != null) // if we were grabing something
			{
			    touchedObject.parent = null; // let the object free
				touchedObject.GetComponent<Rigidbody2D>().isKinematic = false; // let it be affected by reality again
				Physics2D.IgnoreLayerCollision(10, 12, false); // restoring the think I didn't understand before hand
				
				// Below the actual throwing part
                Vector2 force = (touchDetect.position - greenCubeCenter.position).normalized * ThrowForceMagnitude;
                touchedObject.GetComponent<Rigidbody2D>().AddForce(force); // actually throwing the object
				
				touchedObject = null; // we let the object go so we set touchedObject to null
			}
        }
		
		mao1.SetBool("Ligado", ligado); // updating display
    }
