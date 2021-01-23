     public class Reading
    {
    public string Temperature {get; set;}
    private double? _NumTemperature;
    public Double? NumTemperature{
    get{ return _NumTemperature} 
    set{
    Double n;
    bool isNumeric = double.TryParse(Temperature, out n);
    if (isNumeric)
    {
    _NumTemperature = n;
    }
    else
    {
    _NumTemperature = null;
    }
    }}
    }
