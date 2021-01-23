    public static void Update()
		{
			foreach (var a in PhysicsEntities)
			{
				foreach (var b in PhysicsEntities)
				{
					if (a.Equals(b) || 
					    !Collision.ResolveCollision(a, b, Detection) || b.Collided) continue;
					while (Detection == Detection.BoundingBox ? 
						       Collision.BoundingBox(a, b) : 
						       Collision.PixelPerfect(a, b))
					{
						const float moveBy = .5F;
						var moveX = a.Position.X > b.Position.X ? moveBy : -moveBy;
						var moveY = a.Position.Y > b.Position.Y ? moveBy : -moveBy;
						if (a.Movable)
						{
							a.Move(moveX, moveY);
							a.Velocity.Scale(-1);
						}
						else if (b.Movable)
						{
							b.Move(moveX * -1, moveY * -1);
							b.Velocity.Scale(-1);
						}
					}
					a.Update();
					b.Update();
					a.Collided = a.Movable;
				}
			}
			foreach (var entity in PhysicsEntities)
			{
				entity.Update(velocity: true);
				entity.Collided = false;
			}
		}
