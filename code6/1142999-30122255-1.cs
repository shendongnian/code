    public class A
    {
        /// <summary>
        /// name of class
        /// </summary>
        public virtual string Name { get { return this.GetType().Name; } }
    
        public void Construct()
        {
            string className = this.Name;
        }
    }
    
    public class B : A
    {
        /// <summary>
        /// overriden name of class
        /// </summary>
        public override string Name { get { return "Bee"; } }
    }
