        /// <summary>
        /// Re-draw chart area
        /// </summary>
        /// <param name="c">Size of the chart</param>
        /// <param name="index">Index of chart area</param>
        private void ReDrawChartArea(Chart c, int index)
        {       
            //Set known max legend size (can't calculate programmatically as charts are stupid)
            float legendmaxsize = 140;
            //Calculate the percentage of the total size
            float maxpercentage = (legendmaxsize / (float)c.Width) * 100;
            //Get the chart area
            ChartArea area = c.ChartAreas[index];
            //Disable auto size
            area.Position.Auto = false;
            //Set the height as full and width as the remaining percentage
            area.Position.Height = 100;
            area.Position.Width = 100F - maxpercentage;
            //Set the area as top and start position as end of legend
            area.Position.Y = 0;
            area.Position.X = maxpercentage;        
        }
