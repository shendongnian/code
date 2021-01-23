    public interface IDrawable<TColorScheme> 
        where TColorScheme : ColorScheme, new()
    {
    }
    public abstract class ColorScheme {  }
