    float xValue, yValue;
    for (int i = 0; i < dataX.Count; i++)
    {
        if (float.TryParse(dataX[i].ToString(),out xValue) && float.TryParse(dataY[i].ToString(),out yValue))
        {
              nizTacaka[i] = new Tacka(xValue, yValue);
        }
        else
        {
         Console.WriteLine("Conversion failed");
        }
        
    }
