    public class BeastScript : MonoBehaviour
    {
        protected virtual void Update() // "protected" so subclasses can see it
        {                               // and "virtual" so subclasses can override it
            if (Input.anyKeyDown)
                ...
        }
    }
    public class Tester : BeastScript
    {
        protected override Update() // "protected" because overriding methods must not be less accessible than the method they override
        {                           // and "override" to specify that this method overrides a virtual method
            // optional: do stuff before calling BeastScript.Update()
            base.Update(); // this calls BeastScript.Update()
            // optional: do stuff after calling BeastScript.Update()
        }
    }
