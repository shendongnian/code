    private static void UpdateEntities(PhysicsEntity a, PhysicsEntity b)
		{
			var collisionAngle = Math.Atan2(a.Position.Y - b.Position.Y, a.Position.X - b.Position.X);
			if (a.IsMoveable && b.IsMoveable)
			{
				var angleA = a.Velocity.Direction - collisionAngle;
				var angleB = b.Velocity.Direction - collisionAngle;
				var vAx = a.Velocity.Magnitude * Math.Cos(angleA);
				var vAy = a.Velocity.Magnitude * Math.Sin(angleA);
				var vBx = b.Velocity.Magnitude * Math.Cos(angleB);
				var vBy = b.Velocity.Magnitude * Math.Sin(angleB);
				var vfAx = ((vAx * (a.Mass - b.Mass) + 2 * b.Mass * vBx) / (a.Mass + b.Mass)) * a.Material.Elasticity;
				var vfBx = ((vBx * (b.Mass - a.Mass) + 2 * a.Mass * vAx) / (a.Mass + b.Mass)) * b.Material.Elasticity;
				var vfAy = vAy * a.Material.Elasticity;
				var vfBy = vBy * b.Material.Elasticity;
				var magA = Math.Sqrt(Math.Pow(vfAx, 2) + Math.Pow(vfAy, 2));
				var magB = Math.Sqrt(Math.Pow(vfBx, 2) + Math.Pow(vfBy, 2));
				var dirA = Math.Atan2(vfAy, vfAx) + collisionAngle;
				var dirB = Math.Atan2(vfBy, vfBx) + collisionAngle;
				a.Velocity.X = magA * Math.Cos(dirA);
				a.Velocity.Y = magA * Math.Sin(dirA);
				b.Velocity.X = magB * Math.Cos(dirB);
				b.Velocity.Y = magB * Math.Sin(dirB);
			}
			else
			{
				var sign = Math.Sign(collisionAngle);
				collisionAngle *= sign;
				collisionAngle %= Math.PI / 2;
				collisionAngle *= sign;
				if (a.IsMoveable)
				{
					Reflection(ref a, b, collisionAngle);
				}
				else
				{
					Reflection(ref b, a, collisionAngle);
				}
			}
		}
