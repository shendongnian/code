    if(setUpEase)
		{
			// Set the destination of each boardspace
			if(!oneTime)
			{
				beginning = new Vector3(t.position.x, t.position.y, t.position.z);
				destination = new Vector3(t.position.x, t.position.y-10, t.position.z);
				change = new Vector3(0, -10, 0);
				setUpDuration = Random.Range (1.0f, 3.0f);
				oneTime = true;
			}
			// BOUNCING
			currentTime += Time.deltaTime;
			float t2 = currentTime/setUpDuration;
			if(currentTime < setUpDuration)
			{
				if (t2 < (1/2.75f))
				{
					t.position = change*(7.5625f*t2*t2) + beginning;
				}
				else if (t2 < (2/2.75f))
				{
					t.position = change*(7.5625f*(t2-=(1.5f/2.75f))*t2 + 0.75f) + beginning;
				}
				else if (t2 < (2.5f/2.75f))
				{
					t.position = change*(7.5625f*(t2-=(2.25f/2.75f))*t2 + 0.9375f) + beginning;
				}
				else
				{
					t.position = change*(7.5625f*(t2-=(2.625f/2.75f))*t2 + 0.984375f) + beginning;
				}
			}
			else
			{
				t.position = destination;
				if(boardId < 113 && boardId > 92)
					pie.setUpEase2 = true;
				setUpEase=false;
			}
		}
