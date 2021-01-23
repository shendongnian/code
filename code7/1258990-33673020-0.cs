    chart1.Series[1].Points[chart1_POINTINDEX].ToolTip = "Description:" + (string)row["DESC"] +
                                System.Environment.NewLine +
                                "25th Percentile:" + (int)row["25TH_PCT_NUMBER"] +
                                System.Environment.NewLine +
                                "50th Percentile:" + (int)row["50TH_PCT_NUMBER"] +
                                System.Environment.NewLine +
                                "75th Percentile:" + (int)row["75TH_PCT_NUMBER"] +
                                System.Environment.NewLine +
                                "Maximum:" + (int)row["MAX"] +
                                System.Environment.NewLine +
                                "Average:" + (int)row["AVG"] +
                                System.Environment.NewLine +
                                "Minimum:" + (int)row["MIN"];
