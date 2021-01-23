        private struct DataPoint
        {
            public double timePoint;
            public double X;
            public double Y;
            public double Z;
        }
        private struct DataPoints
        {
            public DataPoints(int samples)
            {
                dataPoints = new DataPoint[samples];
            }
            public DataPoint[] dataPoints;
        }
        Queue queue = new Queue();
        int lastSample = 0;
        static int maxPlotPoints = 1000;
        static int samplePoints = 1000;
        public ChartForm(UdpMgrControl RefUdpMgr, byte GyroChartNum, string ConfigFile)
        {
            running = true;
            Thread main_thread = new Thread(new ThreadStart(this.MainTask));
        }
        private void OutputHandler(byte[] DData)
        {
            if (running)
            {
                DataPoints data_element = new DataPoints(samplePoints);
                for (int i = 0; i < samplePoints; i++)
                {
                    data_element.dataPoints[i].X = DData[i].X;
                    data_element.dataPoints[i].Y = DData[i].Y;
                    data_element.dataPoints[i].Z = DData[i].Z;
                    data_element.dataPoints[i].timePoint = DData[i].timePoint;
                }
                queue.Enqueue(data_element);
            }
        }
        private void MainTask()
        {
            while (running)
            {
                try
                {
                    if (queue.Count > 0)
                    {
                        chart1.Series[0].IsXValueIndexed = false;
                        chart1.Series[1].IsXValueIndexed = false;
                        chart1.Series[2].IsXValueIndexed = false;
                        DataPoints data_element = (DataPoints)queue.Dequeue();
                        for (int i = 0; i < data_element.dataPoints.Length; i++)
                            {
                                chart1.Series[0].Points[lastSample + i].XValue = data_element.dataPoints[i].timePoint;
                                chart1.Series[0].Points[lastSample + i].YValues[0] = data_element.dataPoints[i].X;
                                chart1.Series[1].Points[lastSample + i].XValue = data_element.dataPoints[i].timePoint;
                                chart1.Series[1].Points[lastSample + i].YValues[0] = data_element.dataPoints[i].Y;
                                chart1.Series[2].Points[lastSample + i].XValue = data_element.dataPoints[i].timePoint;
                                chart1.Series[2].Points[lastSample + i].YValues[0] = data_element.dataPoints[i].Z;
                            }
                        chart1.Series[0].Enabled = true;
                        chart1.Series[1].Enabled = true;
                        chart1.Series[2].Enabled = true;
                        //Adjust the next location to end of first
                        lastSample = (lastSample + samples) % maxPlotPoints;
                        chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = lastSample;
                        chart1.Series[0].IsXValueIndexed = true;
                        chart1.Series[1].IsXValueIndexed = true;
                        chart1.Series[2].IsXValueIndexed = true;
                        GC_UpdateDataGrids();
                        chart1.Invalidate();
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
                catch (Exception error)
                {
                    LogErrors.AddErrorMsg(error.ToString());
                }
            }
        }
