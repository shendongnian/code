        protected void RETRIEVE_BUTTON_Click(object sender, EventArgs e)
        {
            AjaxControlToolkit.TabContainer container = new AjaxControlToolkit.TabContainer();
            container.ID = DateTime.Now.Millisecond.ToString();
            container.EnableViewState = false;
            container.Tabs.Clear();
            container.Height = Unit.Pixel(500);
            container.Width = Unit.Pixel(1200);
            container.Tabs.AddAt(0, GetManualTab());
            foreach (ListItem item in SelectionListBox.Items)
            {
                if (item.Selected)
                {
                    
                    Label tabContent = new Label();
                    tabContent.ID = "lbl_tab_";
                    tabContent.Text += item.Value;
                    
                    AjaxControlToolkit.TabPanel panel = new AjaxControlToolkit.TabPanel();
                    panel.HeaderText += item.Value;
                    container.Tabs.Add(panel);
                    panel.Controls.Add(tabContent);
                    if (string.Compare(item.Value,"item 1",true) == 0)
                    {
                        ChartArea mainArea;
                        Chart mainChart;
                        Series mainSeries;
                        mainChart = new Chart();
                        mainSeries = new Series("MainSeries");
                        mainSeries.Points.AddXY(1, 1);
                        mainSeries.Points.AddXY(2, 2);
                        mainSeries.Points.AddXY(3, 3);
                        mainSeries.Points.AddXY(4, 4);
                        mainChart.Series.Add(mainSeries);
                        mainArea = new ChartArea("MainArea");
                        mainChart.ChartAreas.Add(mainArea);
                        panel.Controls.Add(mainChart);
                    }
                    if (string.Compare(item.Value,"item 2",true) == 0)
                    {
                        ChartArea mainArea;
                        Chart mainChart;
                        Series mainSeries;
                        mainChart = new Chart();
                        mainSeries = new Series("MainSeries");
                        mainSeries.Points.AddXY(2, 4);
                        mainSeries.Points.AddXY(3, 6);
                        mainSeries.Points.AddXY(4, 8);
                        mainSeries.Points.AddXY(6, 1);
                        mainChart.Series.Add(mainSeries);
                        mainArea = new ChartArea("MainArea");
                        mainChart.ChartAreas.Add(mainArea);
                        panel.Controls.Add(mainChart);
                    }
                    
                }
            }
            PlaceHolder1.Controls.Add(container);
        }
