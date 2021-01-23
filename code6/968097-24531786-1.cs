    namespace UseCppDll
    {
        struct Program
        {
            [DllImport("LoadModelDll", CallingConvention=CallingConvention.Cdecl)]
            public unsafe static extern void GetModelReferences(ref int nVertices, float* vertices,ref int nTriangles, float* triangles, float* normals, float* uvCoordinates);
    
            static void Main(string[] args)
            {
                unsafe {
                    int lnVertices = 0;
                    int lnTriangls = 0;
    
    
                    float* lVertices = stackalloc float[12];
                    float* lTriangles = stackalloc float[6];
                    float* lNormals = stackalloc float[12];
                    float* lUVcoordinates = stackalloc float[8];
    
                    GetModelReferences( ref lnVertices,  lVertices , ref lnTriangls, lTriangles, lNormals, lUVcoordinates);
                }
            }
        }
    }
