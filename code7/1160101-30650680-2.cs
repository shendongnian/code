    // i redefined your enum a bit
    public enum Buttons
    {
        // Default
        Default = 0,
        // Exit flags
        Exit = 1,
        Cancel = Exit << 1,
        Abort = Cancel << 1,
        Close = Abort << 1,
        //Proced flags
        Accept = Close << 1,
        Ok = Accept << 1,
        Submit = Ok << 1,
        //Question flags
        No = Submit << 1,
        Yes = No << 1,
        //Save and load
        Save = Yes << 1,
        SaveAll = Save << 1,
        SaveNew = SaveAll << 1,
        Open = SaveNew << 1,
        Load = Open << 1
    }
