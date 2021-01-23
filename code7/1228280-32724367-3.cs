    /// <summary>
		/// Default vertex shader that only applies specified matrix transformation
		/// </summary>
		public const string vertexShaderDefaultSrc =
			@"
			#version 330
			uniform mat4 MVPMatrix;
			layout (location = 0) in vec2 Position;
			layout (location = 1) in vec2 Texture;
			layout (location = 2) in vec4 Colour;
			out vec2 InVTexture;
			out vec4 vFragColorVs;
			void main()
			{
				gl_Position = MVPMatrix * vec4(Position, 0, 1);
				InVTexture = Texture;
				vFragColorVs = Colour;
			}";
