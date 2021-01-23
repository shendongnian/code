                Dictionary<double, List<double>> GetAllInjData = new Dictionary<double, List<double>>() {
                    {1, new List<double>() {1,2,3,4,5,6}},
                    {2, new List<double>() {11,12,13,14,15,16}},
                    {3, new List<double>() {21,22,23,24,25,26}}
                };
                double results = GetAllInjData[2].Sum();
