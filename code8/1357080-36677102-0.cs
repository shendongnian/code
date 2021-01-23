    public abstract class IInfoCard
    {
        string Name { get; set; }
        string Category { get; }
        string GetDataAsString() { return null; }
        void DisplayData(Panel displayPanel) {}
        void CloseDisplay() {}
        bool EditData() { return true;}
    }
