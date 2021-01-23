    public enum TriggerOn
    {
        [DelayedTrigger]
        CreationDelay,
        NoCreation,
        [DelayedTrigger]
        CollisionDelay,
        CollisionStandard,
        [DelayedTrigger]
        RigidbodyRestDelay,
        [DelayedTrigger]
        LayerCollisionDelay,
        [DelayedTrigger]
        EnterRadiusDelay
    }
    public class DelayedTriggerAttribute : Attribute
    {
    }
