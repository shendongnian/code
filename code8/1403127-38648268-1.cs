            Vector3 V = new Vector3(P.X, P.Y, P.Z);
            Vector3 R = Operator.Project(V, View);
            Vector3 Q = V - R;
            Vector3 A = Operator.Cross(View, zA);
            Vector3 B = Operator.Cross(A, View);
            int pY = (int)(Operator.Dot(Q, B) / B.GetMagnitude());
            int pX = (int)(Operator.Dot(Q, A) / A.GetMagnitude());
