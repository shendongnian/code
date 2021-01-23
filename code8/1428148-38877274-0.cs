            // align the charts
            NSideGuideline guideline = new NSideGuideline(PanelSide.Left);
            guideline.Targets.Add(chart1);
            guideline.Targets.Add(chart2);
            nChartControl1.Document.RootPanel.Guidelines.Add(guideline);
