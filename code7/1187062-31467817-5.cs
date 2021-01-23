    public interface IDriver
    {
    }
    public interface IPowerSupply : IDriver
    {
        void SetVoltage();
        void SetCurrent();
    }
    public interface IMultimeter : IDriver
    {
        double MeasureVoltage();
    }
