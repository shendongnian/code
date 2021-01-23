    // get the last 4 points to average out (plus analogDataIn1)
    int pointCount = chart2.Series[0].Points.Count();
    var buffer = chart2.Series[0].Points.Skip(Math.Max(0, pointCount - 4)).Select(dp => dp.Y);
    // calculate the average Y from these points (along with analogDataIn1)
    double avgAnalogDataIn1;
    if (buffer.Count() == 0)
    {
        avgAnalogDataIn1 = analogDataIn1;
    }
    else
    {
        avgAnalogDataIn1 = (buffer.Sum() + analogDataIn1) / (double)(buffer.Count() + 1);
    }
    
    DataPoint dp0 = new DataPoint(x, avgAnalogDataIn1);
    chart2.Series[0].Points.RemoveAt(0);
    chart2.Series[0].Points.Add(dp0);
    x++;
