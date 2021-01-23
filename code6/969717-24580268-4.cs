        private static void Main(string[] args)
        {
            var raw = new SampleDataStruct[2]
            {
                new SampleDataStruct
                {
                    CityName = "New York", AgeWeight = new AgeWeightStruct[3]
                    {
                        new AgeWeightStruct{Age = 50,Weigth = 70},
                        new AgeWeightStruct{Age = 40,Weigth = 75},
                        new AgeWeightStruct{Age = 30,Weigth = 65}
                    }
                },
    
                new SampleDataStruct
                {
                    CityName = "Berlin", AgeWeight = new AgeWeightStruct[3]
                    {
                        new AgeWeightStruct{Age = 50,Weigth = 65},
                        new AgeWeightStruct{Age = 40,Weigth = 60},
                        new AgeWeightStruct{Age = 30,Weigth = 55}
                    }
                }
            };
    
            Console.WriteLine(raw.Where(st => st.CityName == "Berlin").ElementAtOrDefault(0).AgeWeight.Where(aw => aw.Age == 40).ElementAtOrDefault(0).Weigth); //Berlin -> Age = 40 -> Display Weight (60)
            Console.WriteLine(raw.Where(st => st.CityName == "New York").ElementAtOrDefault(0).AgeWeight.Where(aw => aw.Age == 30).ElementAtOrDefault(0).Weigth); //New York -> Age = 30 -> Display Weight (65)
            Console.ReadKey();
        }
    }
    
    public struct SampleDataStruct
    {
        public string CityName;
        public AgeWeightStruct[] AgeWeight;
    }
    
    public struct AgeWeightStruct
    {
        public int Age;
        public int Weigth;
    }
