    library CarGarage:
    [Serializable]
    public class CarGarage<T>:IEnumerable<T>
        where T : Car,new()
    {
    ...
    }
---
    library DebugVis:  (uses CarGarage)
    DebuggerSide....
