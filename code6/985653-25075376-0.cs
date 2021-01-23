        class Portfolio
        {
            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string Value3 { get; set; }
            public string Method { get; set; }
            public string Period { get; set; }
            public Portfolio(string[] values)
            {
                if (values != null)
                {
                    this.Value1 = values.ElementAtOrDefault(0);
                    this.Value2 = values.ElementAtOrDefault(1);
                    this.Value3 = values.ElementAtOrDefault(2);
                    this.Method = values.ElementAtOrDefault(3);
                    this.Period = values.ElementAtOrDefault(4);
                }
            }
        }
