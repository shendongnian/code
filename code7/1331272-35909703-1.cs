    Html code:   
      <asp:Chart ID="Chart1" runat="server" Height="300px" Width="400px"  >
                <Titles>
                    <asp:Title ShadowOffset="3" Name="Items" />
                </Titles>
                <Legends>
                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" 
                        LegendStyle="Row"  />
                </Legends>
                <Series>
                    <asp:Series Name="Data" Color="Chocolate" BackGradientStyle="HorizontalCenter"   />
                </Series>
                <ChartAreas >
                    <asp:ChartArea Name="ChartArea1"  BorderWidth="0" BackColor="White"   />
                </ChartAreas>
            </asp:Chart> 
    
        Code behind:
        chart.Series["Data"].ChartType = SeriesChartType.Doughnut;
        chart.Series["Data"]["PieLabelStyle"] = "outside";
        chart.Series["Data"]["PieLineColor"] = "LightGray";
        chart.Series["Data"]["DoughnutRadius"] = "30";
        chart.Series["Data"]["PieStartAngle"] = "270";
        chart.ChartAreas[0].InnerPlotPosition.Height = 90;
        chart.ChartAreas[0].InnerPlotPosition.Width = 90;
        chart.ChartAreas[0].Area3DStyle.Enable3D = true;
        chart.ChartAreas[0].Area3DStyle.Inclination = 0;
        chart.Series["Data"].Font = new Font("Arial", 16.0f,    FontStyle.Bold);
        foreach (DataPoint p in chart.Series["Data"].Points)
                        {
                            p.Label = "#PERCENT";
                            p.LabelToolTip = "#VALX";
                            p.LabelForeColor = Color.Brown;
                            p.LegendText = "#VALX";
                            p.LegendToolTip = "#PERCENT";
                            p.LabelToolTip = "#PERCENT\n#VALX";
                            
                        }
