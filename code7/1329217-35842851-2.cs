    public static class Test
    {
    	public static Func<int, Func<int, int>> Add => x => y => x + y;
    	public static Func<int, Func<int, int>> Multiply => x => y => x * y;
    }
