    public static class VectorHelper
    {
        public static void Test()
        {
            var v2 = new Vector2(5, 5);
            var v3 = new Vector3(7, 7, 7);
            var v4 = new Vector4(3, 3, 3, 3);
            var res1 = v2 + v3;
            Debug.Assert(res1.GetType().Name == "Vector3"); // No assert
            var res2 = v3 + v4;
            Debug.Assert(res2.GetType().Name == "Vector4"); // No assert
            var res3 = v2 + v4;
            Debug.Assert(res3.GetType().Name == "Vector4"); // No assert
            Debug.Assert(res3.x == 8 && res3.y == 8 && res3.z == 3 && res3.w == 3); // No assert
        }
    }
