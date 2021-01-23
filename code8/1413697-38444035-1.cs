    using Microsoft.Research.DynamicDataDisplay;
    using Microsoft.Research.DynamicDataDisplay.DataSources;     
    
    private void button_Click(object sender, RoutedEventArgs e)
                {
                    double[] my_array = new double[10];
        
                    for (int i = 0; i < my_array.Length; i++)
                    {
                        my_array[i] = Math.Sin(i);
                        Data.Collection.Add(new Point(i, my_array[i]));
                    }
                    Plotter.AddLineGraph(Data);
                }
