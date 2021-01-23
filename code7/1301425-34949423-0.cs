	public interface IView<V, P, T>
		where V : IView<V, P, T>
		where P : IPresenter<V, P, T>
	{ }
	
	public interface IPresenter<V, P, T>
		where V : IView<V, P, T>
		where P : IPresenter<V, P, T>
	{ }
	
	public abstract class PresenterBase<V, P, T> : IPresenter<V, P, T>
		where V : IView<V, P, T>
		where P : IPresenter<V, P, T>
	{ }
	
	public abstract class ViewBase<V, P, T> : IView<V, P, T>
		where V : IView<V, P, T>
		where P : IPresenter<V, P, T>
	{ }
	
	public class ImplementedPresenter : PresenterBase<SomeImplementedView, ImplementedPresenter, SomeFancyDancyEventArgs>
	{ }
	
	public class SomeImplementedView : ViewBase<SomeImplementedView, ImplementedPresenter, SomeFancyDancyEventArgs>
	{ }
