        private void ilPanel1_Load(object sender, EventArgs e)
        {
            ILPlotCube pc = new ILPlotCube(twoDMode: false);
            ILScene scene = new ILScene { pc };
            ILArray<float> point0 = new float[] { 0, 0.5f, 1 };
            ILArray<float> point1 = new float[] { 0, 1, 1 };
            ILArray<float> point2 = new float[] { 0, 0.75f, 0.75f };
            ILArray<float> point3 = new float[] { 0, 1, 0.5f };
            ILArray<float> XMat = ILMath.zeros<float>(2, 2);
            ILArray<float> YMat = ILMath.zeros<float>(2, 2);
            ILArray<float> ZMat = ILMath.zeros<float>(2, 2);
            XMat["0;0"] = point0[0];
            XMat["0;1"] = point1[0];
            XMat["1;0"] = point2[0];
            XMat["1;1"] = point3[0];
            YMat["0;0"] = point0[1];
            YMat["0;1"] = point1[1];
            YMat["1;0"] = point2[1];
            YMat["1;1"] = point3[1];
            ZMat["0;0"] = point0[2];
            ZMat["0;1"] = point1[2];
            ZMat["1;0"] = point2[2];
            ZMat["1;1"] = point3[2];
            // preallocate data array for ILSurface: X by Y by 3
            // Note the order: 3 matrix slices of X by Y each, for Z,X,Y pointinates of every grid point
            ILArray<float> XYZ = ILMath.zeros<float>(2, 2, 3);
            XYZ[":;:;0"] = ZMat;
            XYZ[":;:;1"] = XMat; // X pointinates for every grid point
            XYZ[":;:;2"] = YMat; // Y pointinates for every grid point
            pc.Add(new ILSurface(XYZ));
            ilPanel1.Scene = scene;
            ilPanel1.Scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(1f, 0.23f, 1f), 0.7f);
        }
