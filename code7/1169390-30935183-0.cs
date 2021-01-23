    public static AnimationSettings PickupAnimationAndReturnSettings(this Shape shape)
    {
        shape.PickupAnimation();
        return shape.AnimationSettings;
    }
