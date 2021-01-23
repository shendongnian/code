    double avg = 0;
    int index = 0;
            foreach (DataRow row in dt.Rows)
            {
                avg = (double)row["Avg"];
                Chart1.Series[0].Points.AddXY(row["Customer"], new object[] { row["Min"], row["Max"], row["Percentile25"], row["Percentile75"], row["Avg"], row["Percentile50"]});
                index = Chart1.Series[1].Points.AddXY(row["Customer"], new object[] { row["Avg"] });
                if (avg >= 0 && avg <= 30)
                {
                    Chart1.Series[1].Points[index].MarkerColor = Color.Green;
                }
                else if (avg > 30 && avg <= 40)
                {
                    Chart1.Series[1].Points[index].MarkerColor = Color.Yellow;
                }
                else if (avg > 40 && avg <= 60)
                {
                    Chart1.Series[1].Points[index].MarkerColor = Color.Red;
                }
            }
