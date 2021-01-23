	//Used for generating the mesh for the curve
	//First object is vertex data, second is indices (both as arrays)
	public static object[] computeCurve3D(int steps)
	{
		List<VertexPositionTexture> path = new List<VertexPositionTexture>();
		List<int> indices = new List<int>();
		List<Vector2> curvePoints = new List<Vector2>();
		for (float x = 0; x < 1; x += 1 / (float)steps)
		{
			curvePoints.Add(getBezierPointRecursive(x, points3D));
		}
		float curveWidth = 0.003f;
		
		for(int x = 0; x < curvePoints.Count; x++)
		{
			Vector2 normal;
			if(x == 0)
			{
				//First point, Take normal from first line segment
				normal = getNormalizedVector(getLineNormal(curvePoints[x+1] - curvePoints[x]));
			}
			else if (x + 1 == curvePoints.Count)
			{
				//Last point, take normal from last line segment
				normal = getNormalizedVector(getLineNormal(curvePoints[x] - curvePoints[x-1]));
			} else
			{
				//Middle point, interpolate normals from adjacent line segments
				normal = getNormalizedVertexNormal(getLineNormal(curvePoints[x] - curvePoints[x - 1]), getLineNormal(curvePoints[x + 1] - curvePoints[x]));
			}
			path.Add(new VertexPositionTexture(new Vector3(curvePoints[x] + normal * curveWidth, 0), new Vector2()));
			path.Add(new VertexPositionTexture(new Vector3(curvePoints[x] + normal * -curveWidth, 0), new Vector2()));
		} 
		for(int x = 0; x < curvePoints.Count-1; x++)
		{
			indices.Add(2 * x + 0);
			indices.Add(2 * x + 1);
			indices.Add(2 * x + 2);
			indices.Add(2 * x + 1);
			indices.Add(2 * x + 3);
			indices.Add(2 * x + 2);
		}
		return new object[] {
			path.ToArray(),
			indices.ToArray()
		};
	}
	
	//Recursive algorithm for getting the bezier curve points 
	private static Vector2 getBezierPointRecursive(float timeStep, Vector2[] ps)
	{
		if (ps.Length > 2)
		{
			List<Vector2> newPoints = new List<Vector2>();
			for (int x = 0; x < ps.Length - 1; x++)
			{
				newPoints.Add(interpolatedPoint(ps[x], ps[x + 1], timeStep));
			}
			return getBezierPointRecursive(timeStep, newPoints.ToArray());
		}
		else
		{
			return interpolatedPoint(ps[0], ps[1], timeStep);
		}
	}
	
	//Gets the interpolated Vector2 based on t
	private static Vector2 interpolatedPoint(Vector2 p1, Vector2 p2, float t)
	{
		return Vector2.Multiply(p2 - p1, t) + p1;
	}
	
	//Gets the normalized normal of a vertex, given two adjacent normals (2D)
	private static Vector2 getNormalizedVertexNormal(Vector2 v1, Vector2 v2) //v1 and v2 are normals
	{
		return getNormalizedVector(v1 + v2);
	}
	//Normalizes the given Vector2
	private static Vector2 getNormalizedVector(Vector2 v)
	{
		Vector2 temp = new Vector2(v.X, v.Y);
		v.Normalize();
		return v;
	}
	//Gets the normal of a given Vector2
	private static Vector2 getLineNormal(Vector2 v)
	{
		Vector2 normal = new Vector2(v.Y, -v.X);            
		return normal;
	}
	
	//Drawing method in main Game class
	//curveData is a private object[] that is initialized in the constructor (by calling computeCurve3D)
	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);
		
		var camPos = new Vector3(0, 0, 0.1f);
		var camLookAtVector = Vector3.Forward;
		var camUpVector = Vector3.Up;
		effect.View = Matrix.CreateLookAt(camPos, camLookAtVector, camUpVector);
		float aspectRatio = graphics.PreferredBackBufferWidth / (float)graphics.PreferredBackBufferHeight;
		float fieldOfView = MathHelper.PiOver4;
		float nearClip = 0.1f;
		float farClip = 200f;
		//Orthogonal
		effect.Projection = Matrix.CreateOrthographic(480 * aspectRatio, 480, nearClip, farClip);
		foreach (var pass in effect.CurrentTechnique.Passes)
		{
			pass.Apply();
			effect.World = Matrix.CreateScale(200);
			graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, 
				(VertexPositionTexture[])curveData[0],
				0,
				((VertexPositionTexture[])curveData[0]).Length,
				(int[])curveData[1],
				0,
				((int[])curveData[1]).Length/3);			
		}
		base.Draw(gameTime);
	}
