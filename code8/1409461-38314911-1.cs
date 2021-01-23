        public class ChartDataMonthly
        {
            public List<decimal[]> _temperature;
            public List<decimal[]> Temperature
            {
                get { return _temperature; }
                set
                {
                    _temperature = value;
                    //edit each value by reference
                    _temperature.ForEach(x => x.ToList().ForEach(y =>y= Convert.ToDecimal(Math.Round(Convert.ToDouble(y)))));
                }
            }
        }
