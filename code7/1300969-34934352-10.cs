	public interface IRoot<out TSecondary, out TTeritary>
		where TSecondary : ISecondary
		where TTeritary : ITertiary
	{
		TSecondary secondary { get; }
		TTeritary tertiary { get; }
	}
