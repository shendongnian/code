        public partial class Form1 : Form
        {
            private const int c_legendItemHeight = 20;
            private const string c_checkCustomPropertyName = "CHECK";
            private const string c_checkedString = "✔"; // see http://www.edlazorvfx.com/ysu/html/ascii.html for more
            private const string c_uncheckedString = "✘";
            private Stock _stock;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                _stock = Stock.Load();
                // mainChart
                mainChart.Legends.Clear();
                foreach (Share share in _stock.Shares)
                {
                    Series series = mainChart.Series.Add(share.Name);
                    series.ChartType = SeriesChartType.Line;
                    foreach (ShareQuotation shareQuotation in share.Quotations)
                    {
                        series.Points.AddXY(shareQuotation.Date.ToString(), shareQuotation.Close);
                    }
                }
                // LegendChart
                Legend legend = legendChart.Legends[0];
                legendChart.Series.Clear();
                legend.IsTextAutoFit = false;
                legend.IsEquallySpacedItems = true;
                legend.MaximumAutoSize = 100;
                legend.Docking = Docking.Left;
                legend.LegendStyle = LegendStyle.Column;
                legend.Position.Auto = true;
                legend.Position.Width = 100;
                legend.Position.Height = 100;
                legend.CellColumns[1].Text = "#CUSTOMPROPERTY(" +c_checkCustomPropertyName+ ")";
                foreach (Share share in _stock.Shares)
                {
                    Series series = legendChart.Series.Add(share.Name);
                    series.SetCustomProperty(c_checkCustomPropertyName,c_checkedString);
                }
                legendChart.Height = _stock.Shares.Count * c_legendItemHeight + 9; // 9 - seems to be constant value
                legendPanel.Height = legendChart.Height;
            }
            private void legendChart_MouseClick(object sender, MouseEventArgs e)
            {
                Point mousePosition = legendChart.PointToClient(Control.MousePosition);
                int seriesNo = mousePosition.Y / c_legendItemHeight;
                Series series = legendChart.Series[seriesNo]; // TODO - check if not out of range 
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // check uncheck series
                    if (series.GetCustomProperty(c_checkCustomPropertyName) == c_checkedString)
                    {
                        // if checked
                        // uncheck
                        series.SetCustomProperty(c_checkCustomPropertyName, c_uncheckedString);
                        series.CustomProperties = series.CustomProperties; // workaround - trigger change - is this a bug?
                        // hide in mainChart
                        mainChart.Series[seriesNo].Enabled = false;
                    }
                    else
                    {
                        // if unchecked
                        legendChart.Series[seriesNo].SetCustomProperty(c_checkCustomPropertyName, c_checkedString);
                        series.CustomProperties = series.CustomProperties; // workaround - trigger change - is this a bug?
                        // show in mainChart
                        mainChart.Series[seriesNo].Enabled = true;
                    }
                }
            }
            private void contextMenu_Opening(object sender, CancelEventArgs e)
            {
                Point mousePosition = legendChart.PointToClient(Control.MousePosition);
                int seriesNo = mousePosition.Y / c_legendItemHeight;
                Series series = legendChart.Series[seriesNo]; // TODO - check if not out of range 
                contextMenu.Items.Clear();
                string state = series.GetCustomProperty(c_checkCustomPropertyName) == c_checkedString ? "visible" : "hidden";
                contextMenu.Items.Add("&Some strange action for " + state + " item named " + series.Name);
                contextMenu.Items.Add("&Another action ...");
            }
        }
