    /// <summary>
        /// Test for a Multisampled fragment shader - http://www.opentk.com/node/2251
        /// </summary>
        public const string fragmentShaderTestSrc =
        @"
		#version 330
		uniform sampler2DMS Sampler;
		in vec2 InTexture;
		in vec4 OutColour;
		out vec4 OutFragColor;
        int samples = 16;
        float div= 1.0/samples;
		void main()
		{
			OutFragColor = vec4(0.0);
            ivec2 texcoord = ivec2(textureSize(Sampler) * InTexture); // used to fetch msaa texel location
            for (int i=0;i<samples;i++)
            {
                OutFragColor += texelFetch(Sampler, texcoord, i) * OutColour;  // add  color samples together
            }
 
            OutFragColor*= div; //devide by num of samples to get color avg.
		}
		";
