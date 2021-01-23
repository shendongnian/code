    public interface IDrawable<TColorScheme> 
        where TColorScheme : ColorScheme
    {
        Area ScreenArea { get; }
        List<char[]> DisplayChars { get; }
        //some other properties...
        TColorScheme ColorScheme { get; }
    }
