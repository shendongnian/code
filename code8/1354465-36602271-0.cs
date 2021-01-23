    namespace WiiDesktopVR
    {
    	public class WiiDesktopVR : Form
    	{
            struct Vertex
            {
                float x, y, z;
                float tu, tv;
    
                public Vertex(float _x, float _y, float _z, float _tu, float _tv)
                {
                    x = _x; y = _y; z = _z;
                    tu = _tu; tv = _tv;
                }
    
                public static readonly VertexFormats FVF_Flags = VertexFormats.Position | VertexFormats.Texture1;
            };
    
            Vertex[] targetVertices =
    		{
    			new Vertex(-1.0f, 1.0f,.0f,  0.0f,0.0f ),
    			new Vertex( 1.0f, 1.0f,.0f,  1.0f,0.0f ),
    			new Vertex(-1.0f,-1.0f,.0f,  0.0f,1.0f ),
    			new Vertex( 1.0f,-1.0f,.0f,  1.0f,1.0f ),
            };
    	}
    	
        class Point2D
        {
            public float x = 0.0f;
            public float y = 0.0f;
            public void set(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
