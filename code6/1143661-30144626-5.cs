    double getAverage(Series series, int first, int last)
    {
        double sum = 0;
        for (int i = first; i < last; i++) sum += series.Points[i].YValues[0];
        return sum / (last - first + 1);
    }
    double getMixMax(Series series, int first, int last, bool min)
    {
        double val = 0;
        for (int i = first; i < last; i++)
        {
            double v = series.Points[i].YValues[0];
            if ( (min && val > v) || (!min && val >= v)) val = v;
        }
        return val;
    }
