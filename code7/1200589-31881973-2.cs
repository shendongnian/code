            foreach (KeyValuePair<string, int> exception in ExceptionMessages)
            {
                chart1.Series[0].Points.AddXY(exception.Key, exception.Value);
                //add business logic for your color here
                if (exception.Key == "Exception 4")
                    chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = Color.Red;
            }
