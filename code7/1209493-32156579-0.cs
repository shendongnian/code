    Coroutine longPressCoroutine = null;
	bool longPress = false;
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			longPressCoroutine = StartCoroutine(PlayerAnimationAfterTime());
		}
		else if(Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			if(longPressCoroutine != null)
			{
				StopCoroutine(longPressCoroutine);
				// if you want to play second animation only in case of longpress then use this 
				//check otherwise just play your animation here;
				if(longPress)
				{
					//play your second animation here
				}
				longPress = false;
			}
		}
    }
    IEnumerator PlayerAnimationAfterTime()
	{
		yield return new WaitForSeconds(2f);
		//Play your first animation here;
		longPress = true;
	}
