    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        [System.ComponentModel.Designer(typeof(MyChartDesigner))]
        public class MyChart : Chart
        {
        }
    
        // Add Project Ref:  System.Design
        internal class MyChartDesigner : System.Windows.Forms.Design.ControlDesigner
        {
            public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
            {
                if ((this.Control != null) && this.Control is Chart)
                {
                    Chart control = (Chart)this.Control;
                    if ((control.ChartAreas.Count == 0) && (control.Series.Count == 0))
                    {
                        ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                        Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
    
                        chartArea1.AxisX.Title = "Time (s)";
                        chartArea1.AxisY.Title = "Value(%)";
                        chartArea1.Name = "MainChartArea";
                        series1.ChartArea = "MainChartArea";
                        series1.ChartType = SeriesChartType.FastLine;
                        series1.Name = "Series1";
    
                        control.ChartAreas.Add(chartArea1);
                        control.Series.Add(series1);
                    }
                }
                base.InitializeNewComponent(defaultValues);
            }
        }
    }
