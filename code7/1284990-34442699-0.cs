    public abstract class AbstractTween<T> : MonoBehaviour {
    protected List<T> items = new List<T>();
}
    public class ValueTween : AbstractTween<ValueTweenItem>
    {   ... }
    public class Tween : AbstractTween<TweenItem>
    {   ... }
