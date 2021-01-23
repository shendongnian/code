        public void RightHandRulePlane_Accord()
        {
            {
                var plane = System.Numerics.Plane.CreateFromVertices
                    (
                     new System.Numerics.Vector3( 0, 0.5f, 0 )
                     , new System.Numerics.Vector3( 1, 0.5f, 0 )
                     , new System.Numerics.Vector3( 0, 0.5f, 1 ) );
                Console.WriteLine( plane.ToString() );
                plane = System.Numerics.Plane.CreateFromVertices
                    (
                     new System.Numerics.Vector3( 0, 0.5f, 1 )
                     , new System.Numerics.Vector3( 1, 0.5f, 0 )
                     , new System.Numerics.Vector3( 0, 0.5f, 0 )
                    );
                Console.WriteLine( plane.ToString() );
            }
            {
                var plane = Accord.Math.Plane.FromPoints
                    (
                     new Accord.Math.Point3( 0, 0.5f, 0 )
                     , new Accord.Math.Point3( 1, 0.5f, 0 )
                     , new Accord.Math.Point3( 0, 0.5f, 1 ) );
                Console.WriteLine( plane.ToString() );
                plane = Accord.Math.Plane.FromPoints
                    (
                     new Accord.Math.Point3( 0, 0.5f, 1 )
                     , new Accord.Math.Point3( 1, 0.5f, 0 )
                     , new Accord.Math.Point3( 0, 0.5f, 0 )
                    );
                Console.WriteLine( plane.ToString() );
            }
        }
