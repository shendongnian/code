    public class FireEffect : BaseEffect
    {
        public static EventDispatcher FireEffectEventDispatcher = new EventDispatcher(null,null);
        public FireEffect(BaseAbility effectOwner)
        {
            this.Owner = effectOwner;
            this.Name = "Fire";
        }
        public override void CalculateEffect(Unit target)
        {
            // set the event here (to get the target as argument for the event)
            FireEffectEventDispatcher.mySender = Owner;
            FireEffectEventDispatcher.myArgument = new EffectEventArgs(target);
            // Fire the event
            FireEffectEventDispatcher.DispatchMyEvent();
            //If you still want the base effect firing.
            base.CalculateEffect(target);
        } 
    }
