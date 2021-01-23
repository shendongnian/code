    public static class MyVisualizers
    {
        public const string AssemblyRef = @"MyVisualizers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
    }
    
    [DebuggerVisualizer("MyVisualizersNamespace.CarGarageVisualizer+DebuggerSide, " + MyVisualizers.AssemblyRef)]
    [Serializable]
    public class CarGarage<T>:IEnumerable<T>
        where T : Car,new()
    {
        ...
    }
