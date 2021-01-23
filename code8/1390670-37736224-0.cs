    public static void Update()
		{
			for (var iterator = 0; iterator < PhysicsEntities.Count; iterator++)
			{
				for (var index = iterator + 1; index < PhysicsEntities.Count; index++)
				{
					if (!Collision.ResolveCollision(PhysicsEntities[iterator], PhysicsEntities[index], Detection) || PhysicsEntities[index].Collided) continue;
					PhysicsEntities[index].Update();
					while (Detection == Detection.BoundingBox ? Collision.BoundingBox(PhysicsEntities[iterator], PhysicsEntities[index]) : Collision.PixelPerfect(PhysicsEntities[iterator], PhysicsEntities[index]))
					{
						const float moveBy = .5F;
						var moveX = PhysicsEntities[iterator].Position.X > PhysicsEntities[index].Position.X ? moveBy : -moveBy;
						var moveY = PhysicsEntities[iterator].Position.Y > PhysicsEntities[index].Position.Y ? moveBy : -moveBy;
						if (PhysicsEntities[iterator].Movable)
						{
							PhysicsEntities[iterator].Move(moveX, moveY);
							PhysicsEntities[iterator].Velocity.Scale(-1);
						}
						else if (PhysicsEntities[index].Movable)
						{
							PhysicsEntities[index].Move(moveX * -1, moveY * -1);
							PhysicsEntities[index].Velocity.Scale(-1);
						}
					}
					PhysicsEntities[iterator].Collided = PhysicsEntities[iterator].Movable;
				}
			}
			foreach (var entity in PhysicsEntities)
			{
				entity.Update(velocity: true);
				entity.Collided = false;
			}
		}
	}
