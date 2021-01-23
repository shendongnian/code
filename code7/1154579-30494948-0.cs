        void IModel.Draw( ) {
			GL.BindVertexArray( m_GLVertexArray );
			GL.BindBuffer( BufferTarget.ElementArrayBuffer, m_GLIndexBuffer ); //Rebinding the GL_ELEMENT_ARRAY_BUFFER solved the second issue.
			GL.DrawElements( PrimitiveType.Triangles, m_Backing.Indices.Count, DrawElementsType.UnsignedInt, 0 );
			GL.BindBuffer( BufferTarget.ElementArrayBuffer, 0 );
			GL.BindVertexArray( 0 );
		}
