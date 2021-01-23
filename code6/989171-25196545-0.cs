    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using TimerTest.Timing.Timers;
    
    namespace TimerTest.Timing
    {
        /// <summary>
        ///   A class for testing the performance of different timers
        /// </summary>
        public class TimerTester
        {
            #region Private Fields
    
            private readonly Chart _outputChart;
            private readonly TextBox _outputTextBox;
            private readonly List<AbstractTimer> _timers = new List<AbstractTimer>();
    
            #endregion
    
            #region Properties
    
            /// <summary>
            ///   Enable or disable the Timer Tester
            /// </summary>
            public bool Enabled
            {
                get { return _timers.Count > 0 && _timers[0].Enabled; }
                set
                {
                    foreach (var timer in _timers)
                    {
                        timer.Enabled = value;
                    }
                    if (value)
                    {
                        foreach (var series in OutputChart.Series)
                        {
                            series.Points.Clear();
                        }
                    }
                }
            }
    
            /// <summary>
            ///   The chart that the tester is plotting to
            /// </summary>
            public Chart OutputChart
            {
                get { return _outputChart; }
            }
    
            /// <summary>
            ///   The text box that the tester is writing to
            /// </summary>
            public TextBox OutputTextBox
            {
                get { return _outputTextBox; }
            }
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            ///   Initializes an instance of TimerTester
            /// </summary>
            /// <param name="form"> The form that the timer's tick event should target </param>
            /// <param name="interval"> The timer interval length in ms </param>
            /// <param name="outputChart"> The chart that the tester is plotting to </param>
            /// <param name="outputTextBox"> The text box that the tester is writing to </param>
            public TimerTester(Form form, double interval, Chart outputChart, TextBox outputTextBox)
            {
                _outputChart = outputChart;
                _outputTextBox = outputTextBox;
                //_timers.Add(new SystemTimer(form, interval));
                //_timers.Add(new FormTimer(form, interval));
                _timers.Add(new MultimediaTimer(form, interval));
    
                // Set Up Events
                foreach (var timer in _timers)
                {
                    timer.Tick += TimerOnTick;
                }
    
                // Set Up Chart
                ChartArea chartArea = OutputChart.ChartAreas[0];
                chartArea.AxisY.Title = "Drift Per Hour [ ms / hr ]";
                chartArea.AxisX.Title = "Time [ min ]";
                chartArea.AxisX.RoundAxisValues();
    
                // Clear existing series
                OutputChart.Series.Clear();
    
                foreach (var timer in _timers)
                {
                    // Set Up Timer Series
                    Series series = OutputChart.Series.Add(timer.Name);
                    series.ChartType = SeriesChartType.Line;
                    series.BorderWidth = 2;
                }
            }
    
            #endregion
    
            #region Private Methods
    
            /// <summary>
            ///   Get the Series associated with a timer
            /// </summary>
            /// <param name="timer"> The timer associated with the series </param>
            /// <returns> The timer's series </returns>
            private Series GetSeries(AbstractTimer timer)
            {
                foreach (var series in OutputChart.Series)
                {
                    if (series.Name == timer.Name)
                    {
                        return series;
                    }
                }
                return null;
            }
    
            /// <summary>
            ///   Handle tick events
            /// </summary>
            /// <param name="sender"> The timer which sent the event </param>
            /// <param name="tickEventArgs"> Event args </param>
            private void TimerOnTick(object sender, TickEventArgs tickEventArgs)
            {
                AbstractTimer timer = (AbstractTimer) sender;
    
                const int roundTo = 1;
                double dateElapsedSeconds = Math.Round(tickEventArgs.ElapsedTime.TotalSeconds, roundTo);
                double dateElapsedMinutes = tickEventArgs.ElapsedTime.TotalSeconds/60;
                double timerElapsedSeconds = Math.Round(tickEventArgs.TimerElapsedSeconds, roundTo);
                double driftMsPerHour = Math.Round(tickEventArgs.DriftMsPerHour, roundTo);
                double driftMsPerInterval = Math.Round(tickEventArgs.DriftMsPerInterval, roundTo);
    
                // Plot Timer Data
                Series series = GetSeries(timer);
                series.Points.AddXY(dateElapsedMinutes, driftMsPerHour);
    
                // Set Up Strings for Output Textbox
                string dateElapsedSecondsString = dateElapsedSeconds.ToString();
                if (!dateElapsedSecondsString.Contains("."))
                {
                    dateElapsedSecondsString += ".0";
                }
                string timerElapsedSecondsString = timerElapsedSeconds.ToString();
                if (!timerElapsedSecondsString.Contains("."))
                {
                    timerElapsedSecondsString += ".0";
                }
                string driftMsPerHourString = driftMsPerHour.ToString();
                if (!driftMsPerHourString.Contains("."))
                {
                    driftMsPerHourString += ".0";
                }
                string driftMsPerIntervalString = driftMsPerInterval.ToString();
                if (!driftMsPerIntervalString.Contains("."))
                {
                    driftMsPerIntervalString += ".0";
                }
                string name = timer.Name.PadRight(20, ' ') + " - ";
    
                OutputTextBox.AppendText(name);
                OutputTextBox.AppendText("Interval: " + tickEventArgs.TimerIntervalsElapsed);
                OutputTextBox.AppendText(" - Timer Elapsed: " + timerElapsedSecondsString);
                OutputTextBox.AppendText(" - DateTime Elapsed: " + dateElapsedSecondsString);
                OutputTextBox.AppendText(" - Ms Drift Per Hour: " + driftMsPerHourString);
                OutputTextBox.AppendText(" - Ms Drift Per Interval: " + driftMsPerIntervalString);
                OutputTextBox.AppendText(Environment.NewLine);
            }
    
            #endregion
        }
    }
        
