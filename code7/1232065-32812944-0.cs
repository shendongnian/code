		public bool CheckCollision( Vector2[] Points, Vector2 Position )
		{
			double MinX = Points.Min( a => a.X );
			double MinY = Points.Min( a => a.Y );
			double MaxX = Points.Max( a => a.X );
			double MaxY = Points.Max( a => a.Y );
			if( Position.X < MinX || Position.X > MaxX || Position.Y < MinY || Position.Y > MaxY )
				return false;
			int I = 0;
			int J = Points.Count() - 1;
			bool IsMatch = false;
			for( ; I < Points.Count(); J = I++ )
			{
				//When the position is right on a point, count it as a match.
				if( Points[ I ].X == Position.X && Points[ I ].Y == Position.Y )
					return true;
				if( Points[ J ].X == Position.X && Points[ J ].Y == Position.Y )
					return true;
				//When the position is on a horizontal or vertical line, count it as a match.
				if( Points[ I ].X == Points[ J ].X && Position.X == Points[ I ].X && Position.Y >= Math.Min( Points[ I ].Y, Points[ J ].Y ) && Position.Y <= Math.Max( Points[ I ].Y, Points[ J ].Y ) )
					return true;
				if( Points[ I ].Y == Points[ J ].Y && Position.Y == Points[ I ].Y && Position.X >= Math.Min( Points[ I ].X, Points[ J ].X ) && Position.X <= Math.Max( Points[ I ].X, Points[ J ].X ) )
					return true;
				if( ( ( Points[ I ].Y > Position.Y ) != ( Points[ J ].Y > Position.Y ) ) && ( Position.X < ( Points[ J ].X - Points[ I ].X ) * ( Position.Y - Points[ I ].Y ) / ( Points[ J ].Y - Points[ I ].Y ) + Points[ I ].X ) )
				{
					IsMatch = !IsMatch;
				}
			}
			return IsMatch;
		}
