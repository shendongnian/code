    public interface IDrawable { } 
    public interface IDrawable<TDrawable, TColorScheme> : IDrawable
		where TDrawable : IDrawable, new()
		where TColorScheme : ColorScheme<TDrawable>, new()
    {
        object ScreenArea { get; }
        List<char[]> DisplayChars { get; }
        //some other properties...
        TColorScheme ColorScheme { get; }
    }
	
    public abstract class ColorScheme<TDrawable>
		where TDrawable : IDrawable, new()
	{
	}
