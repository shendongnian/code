    using System.Runtime.InteropServices;
    namespace UseCppDll
    {
        class Program
        {
            [DllImport("LoadModelDll", CallingConvention=CallingConvention.Cdecl)]
            public unsafe static extern void GetModelReferences(ref int nVertices, ref float[] vertices,ref int nTriangles,ref float[] triangles,ref float[] normals,ref float[] uvCoordinates);
    
            static void Main(string[] args)
            {
                unsafe {
                    int lnVertices = 0;
                    int lnTriangls = 0;
    
    
                    float[] lVertices = new float[12];
                    float[] lTriangles = new float[6];
                    float[] lNormals = new float[12];
                    float[] lUVcoordinates = new float[8];
    
                    GetModelReferences(ref lnVertices,  ref lVertices ,ref lnTriangls,ref lTriangles,ref lNormals,ref lUVcoordinates);
                }
            }
        }
    }
