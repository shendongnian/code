    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CandidateApiIgnore : Attribute
    {
        public CandidateApiIgnore() { }
    }
    
    public class FormDataElementBase
    {
    ///...
        [CandidateApiForMenuItem("Remove")]
        public virtual void Remove()
        {
            ///...
        }
    
        public void GenerateGroupPopupMenuItems()
        {
            foreach (MethodInfo methodInfo in this.GetType().GetMethods())
            {
                if (methodInfo.GetCustomAttribute(typeof(CandidateApiForMenuItem)) != null &&
                    methodInfo.GetCustomAttribute(typeof(CandidateApiIgnore)) == null)
                {
                    // If a method is overridden and marked with
                    // CandidateApiIgnore attribute in a derived
                    // class, it won't be processed here.
                };
            };
    }
    
    public class MainGroup : FormDataElementBase
    {
        [CandidateApiIgnore]
        public override void Remove()
        {
            throw new NotSupportedException();
        }
    }
