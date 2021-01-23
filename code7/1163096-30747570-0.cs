		float someSmallValue = 0.5f; // Adjust this as per your needs
		if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < someSmallValue)
		{
			switch (moveType)
			{
				case MoveType.Forward:
					currentPoint++;
					if (currentPoint > patrolPoints.Length - 1)
					{
						currentPoint -= 1;
						moveType = MoveType.Backwards;
					}
				break;
			    case MoveType.Backwards:
					if (currentPoint < 0)
					{
						currentPoint = 1;
						moveType = MoveType.Forward;
					}
				break;
			}
		}
