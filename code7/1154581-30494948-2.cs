    	public IModel LoadData( Shape a_Shape ) {
			m_Backing = a_Shape;
			Single[] Positions = new Single[a_Shape.Vertices.Count * 3];
			Single[] Normals = new Single[a_Shape.Vertices.Count * 3];
			Single[] TexCoords = new Single[a_Shape.Vertices.Count * 2];
			for ( int i = 0; i < Positions.Length; i += 3 ) {
				Positions[i + 0] = a_Shape.Vertices[i / 3].Position.X;
				Positions[i + 1] = a_Shape.Vertices[i / 3].Position.Y;
				Positions[i + 2] = a_Shape.Vertices[i / 3].Position.Z;
				Normals[i + 0] = a_Shape.Vertices[i / 3].Normal.X;
				Normals[i + 1] = a_Shape.Vertices[i / 3].Normal.Y;
				Normals[i + 2] = a_Shape.Vertices[i / 3].Normal.Z;
			}
			for ( int i = 0; i < TexCoords.Length; i += 2 ) {
				TexCoords[i + 0] = a_Shape.Vertices[i / 2].TexCoord.X;
				TexCoords[i + 1] = a_Shape.Vertices[i / 2].TexCoord.Y;
			}
			m_GLVertexArray = GL.GenVertexArray( );
			GL.BindVertexArray( m_GLVertexArray );
			m_GLIndexBuffer = GL.GenBuffer( );
			GL.GenBuffers( 3, m_GLDataBuffers );
			GL.BindBuffer( BufferTarget.ElementArrayBuffer, m_GLIndexBuffer );
			GL.BufferData( BufferTarget.ElementArrayBuffer, ( IntPtr ) ( sizeof ( uint ) * a_Shape.Indices.Count ), a_Shape.Indices.ToArray( ), BufferUsageHint.StaticDraw );
			GL.BindBuffer( BufferTarget.ArrayBuffer, m_GLDataBuffers[0] ); // Bind the Position Buffer
			GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr ) ( sizeof ( Single ) * Positions.Length ), Positions, BufferUsageHint.StaticDraw );
			GL.VertexAttribPointer( 0, 3, VertexAttribPointerType.Float, false, 0, 0 );
			GL.EnableVertexAttribArray( 0 );
			GL.BindBuffer( BufferTarget.ArrayBuffer, m_GLDataBuffers[1] ); // Bind the Normal Buffer
			GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr ) ( sizeof ( Single ) * Normals.Length ), Normals, BufferUsageHint.StaticDraw );
			GL.VertexAttribPointer( 1, 3, VertexAttribPointerType.Float, false, 0, 0 );
			GL.EnableVertexAttribArray( 1 );
			GL.BindBuffer( BufferTarget.ArrayBuffer, m_GLDataBuffers[2] ); // Bind the TexCoord Buffer
			GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr ) ( sizeof ( Single ) * TexCoords.Length ), TexCoords, BufferUsageHint.StaticDraw );
			GL.VertexAttribPointer( 2, 2, VertexAttribPointerType.Float, false, 0, 0 );
			GL.EnableVertexAttribArray( 2 );
			GL.BindBuffer( BufferTarget.ArrayBuffer, 0 );
			GL.BindVertexArray( 0 );
			GL.BindBuffer( BufferTarget.ElementArrayBuffer, 0 );
			return this;
		}
