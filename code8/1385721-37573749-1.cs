    		private static void Reflection(ref PhysicsEntity movable, PhysicsEntity immovable, double collisionAngle)
		{
			if (Math.Abs(collisionAngle - Math.PI / 2) < Universe.Epsilon)
			{
				// take the velocity vector, rotate it 180 degrees, scale it
				movable.Velocity.X *= -1;
				movable.Velocity.Y *= -1;
			}
			else if (Math.Abs(movable.Position.Y - immovable.Position.Y) < Universe.Epsilon ||
			         (movable.Position.X > movable.CollisionPoint.X ^ movable.Position.Y < movable.CollisionPoint.Y))
			{
				//take velocity vector, rotate CCW by 2*collisionAngle, scale it
				var rotateAngle = 2 * collisionAngle;
				var xPrime = movable.Velocity.X * Math.Cos(rotateAngle) - movable.Velocity.Y * Math.Sin(rotateAngle);
				var yPrime = movable.Velocity.Y * Math.Cos(rotateAngle) - movable.Velocity.X * Math.Sin(rotateAngle);
				movable.Velocity.X = xPrime;
				movable.Velocity.Y = yPrime;
			}
			else
			{
				//take the vector, rotate it CCW by 360-2*collisionAngle, scale it
				var rotateAngle = 2 * (Math.PI - collisionAngle);
				var xPrime = movable.Velocity.X * Math.Cos(rotateAngle) - movable.Velocity.Y * Math.Sin(rotateAngle);
				var yPrime = movable.Velocity.Y * Math.Cos(rotateAngle) - movable.Velocity.X * Math.Sin(rotateAngle);
				movable.Velocity.X = xPrime;
				movable.Velocity.Y = yPrime;
			}
			movable.Velocity.X *= movable.Material.Elasticity;
			movable.Velocity.Y *= movable.Material.Elasticity;
		}
