    private void ChartMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult[] htrList = Chart.HitTest(e.X, e.Y, false, ChartElementType.DataPoint);
                // loop through all of the elements in htrList, and make the "child" chart
            }
            catch (Exception)
            {
                StatusLabelText = "";
            }
        }
