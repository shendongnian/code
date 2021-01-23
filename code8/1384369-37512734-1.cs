    private Car GetCarFromFile(string strFilePath)
    {
        var lstCarFile = System.IO.File.ReadAllLines(strFilePath);
    
        var car = new Car();
        foreach (var c in lstCarFile)
        {
            var name = c.Split(',')[0].Trim();
            var value = c.Split(',')[1].Trim();
    
            car.GetType().GetProperty(name).SetValue(car, value, null);
        }
    
        return car;
    }
