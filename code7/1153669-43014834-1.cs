    public static double[] getBoneVectorOutofJointPosition(BVHBone bvhBone, Skeleton skel)
    {
        double[] boneVector = new double[3] { 0, 0, 0 };
        double[] boneVectorParent = new double[3] { 0, 0, 0 };
        string boneName = bvhBone.Name;
    
        JointType Joint;
        if (bvhBone.Root == true)
        {
            boneVector = new double[3] { 0, 0, 0 };
        }
        else
        {
            if (bvhBone.IsKinectJoint == true)
            {
                Joint = KinectSkeletonBVH.String2JointType(boneName);
    
                boneVector[0] = skel.Joints[Joint].Position.X;
                boneVector[1] = skel.Joints[Joint].Position.Y;
                boneVector[2] = skel.Joints[Joint].Position.Z;
    ..
