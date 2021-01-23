    public abstract class Agent
    {
        protected IPhysics PluginPhysics { get; private set; }
    
        protected Agent(...)
        {
            var physics = CreatePhysics();
            SetupPhysics(physics);
        }
    
        void SetupPhysics(Physics physics)
        {
            this.PluginPhysics = physics;
        }
    
        protected abstract IPhysics CreatePhysics();
    }
    
    public class Bicycle : Agent
    {
        private double maxA;
        protected override IPhysics CreatePhysics()
        {
            ComputationOfMaxA();
            return new Physics(maxA);
        }
    }
