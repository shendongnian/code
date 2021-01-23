    public static void Update()
		{
			for (var a = 0; a < PhysicsEntities.Count; a++)
			{
				for (var b = a + 1; b < PhysicsEntities.Count; b++)
				{
					if (!Collision.ResolveCollision(PhysicsEntities[a], PhysicsEntities[b], Detection)
					    || PhysicsEntities[b].Collided) continue;
					PhysicsEntities[b].Update();
					while (Detection == Detection.BoundingBox ? 
						       Collision.BoundingBox(PhysicsEntities[a], PhysicsEntities[b]) : 
						       Collision.PixelPerfect(PhysicsEntities[a], PhysicsEntities[b]))
					{
						const float moveBy = .5F;
						var moveX = PhysicsEntities[a].Position.X > PhysicsEntities[b].Position.X ? 
							            moveBy : -moveBy;
						var moveY = PhysicsEntities[a].Position.Y > PhysicsEntities[b].Position.Y ?
							            moveBy : -moveBy;
						if (PhysicsEntities[a].Movable)
						{
							PhysicsEntities[a].Move(moveX, moveY);
							PhysicsEntities[a].Velocity.Scale(-1);
						}
						else if (PhysicsEntities[b].Movable)
						{
							PhysicsEntities[b].Move(moveX * -1, moveY * -1);
							PhysicsEntities[b].Velocity.Scale(-1);
						}
					}
					PhysicsEntities[a].Collided = PhysicsEntities[a].Movable;
				}
			}
			foreach (var entity in PhysicsEntities)
			{
				entity.Update(velocity: true);
				entity.Collided = false;
			}
		}
