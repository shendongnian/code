    using UnityEngine;
    using System.Collections;
    
    public class CircleShapeGenerator : MonoBehaviour {
    
    	public int segments = 100;
    	public int edgeSegments = 10;
    	public float radius = 1f; 
    
    	int vertCount;
    	float increAngle, increAngleEdge;
    
    	public Color c1 = new Color( 1, 1, 1, 1f );
    	public Color c2 = new Color( 1, 1, 1, 1f );
    	
    	LineRenderer line;
    
    	void Start ()
    	{
    		vertCount = segments + 2*edgeSegments - 2 + 1;
    		increAngle = 360f / segments;
    		increAngleEdge = increAngle/edgeSegments;
    
    		line = gameObject.AddComponent<LineRenderer>();
    
    		line.material = new Material(Shader.Find("Particles/Additive"));
    		line.SetWidth(0.05F, 0.05F);
    		line.SetVertexCount (vertCount);
    		line.useWorldSpace = false;
    	}
    
    	void Update()
    	{
    		line.SetColors(c1, c2);
    
    		//draw first segment
    		float angle = 0;
    		for (int i = 0; i < edgeSegments; i++)
    		{
    			float x = Mathf.Sin (Mathf.Deg2Rad * angle) * radius;
    			float y = Mathf.Cos (Mathf.Deg2Rad * angle) * radius;
    			
    			line.SetPosition( i, new Vector3(x, y, 0) );
    			angle += increAngleEdge;
    		}
    
    		//draw from seconds to last-1  segment
    		angle -= increAngleEdge;
    		for (int i = 0; i < segments-2; i++)
    		{
    			angle += increAngle;
    
    			float x = Mathf.Sin (Mathf.Deg2Rad * angle) * radius;
    			float y = Mathf.Cos (Mathf.Deg2Rad * angle) * radius;
    			
    			line.SetPosition( edgeSegments + i, new Vector3(x, y, 0) );
    		}
    
    		//draw last segment
    		for (int i = 0; i < edgeSegments+1; i++)
    		{
    			angle += increAngleEdge;
    
    			float x = Mathf.Sin (Mathf.Deg2Rad * angle) * radius;
    			float y = Mathf.Cos (Mathf.Deg2Rad * angle) * radius;
    			
    			line.SetPosition( edgeSegments + segments - 2 + i, new Vector3(x, y, 0) );
    		}
    	}
    }
