    private void Update()
	{
		for (var i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				var worldPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
				transform.position = worldPosition;
			}
		}
	}
