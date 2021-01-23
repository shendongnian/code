    BoneInfo GetBoneInfo(HumanBodyBones id) {
        int boneid = (int)id.GetHashCode();
        BoneInfo info = new BoneInfo();
        
        info.muscleMax = HumanTrait.GetMuscleDefaultMax(boneid);
        info.muscleMin = HumanTrait.GetMuscleDefaultMin(boneid);
        info.transform = anim.GetBoneTransform(id);
        return info;
    }
