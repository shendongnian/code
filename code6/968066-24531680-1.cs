        // Classic chart
        Chart chart = new Chart();
        chart.Series.Add(new Series("Classic series instance for Chart"));
        chart.Series.Add(new MySeries("My series instance for Chart"));
        this.Controls.Add(chart);
        // MyChart
        MyChart myChart = new MyChart();
        chart.Series.Add(new Series("Classic series instance for MyChart"));
        chart.Series.Add(new MySeries("My series instance for MyChart"));
        this.Controls.Add(myChart );
        ...
        myChart.MyChartMethod()
