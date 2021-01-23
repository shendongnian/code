    public static ASMATRIX4 operator *(ASMATRIX4 mA, ASMATRIX4 mB)
    {
        //  Creates a new identity matrix
        var m = new ASMATRIX4();
        // Multiply the two matrixes together and return the output matrix
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                m.Matrix[i].Points[j] =
                    (mB.Matrix[i].Points[0]*mA.Matrix[0].Points[j]) +
                    (mB.Matrix[i].Points[1]*mA.Matrix[1].Points[j]) +
                    (mB.Matrix[i].Points[2]*mA.Matrix[2].Points[j]) +
                    (mB.Matrix[i].Points[3]*mA.Matrix[3].Points[j]);   //  <----
            }
        }
        return m;
    }
