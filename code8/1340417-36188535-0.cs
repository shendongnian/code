    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        public class Car
        {
            public string CarBrand { get; set; }
            public List<CarModel> carModel;
        }
    
        public class CarModel
        {
            public string Name { get; set; }
            public string YearOfProduction { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List<Car>();
                list.Add(
                    new Car
                        {
                            CarBrand = "Ford",
                            carModel = new List<CarModel>{ 
                                new CarModel{Name="Fiesta", YearOfProduction="2010"},
                                new CarModel{Name="Fiesta", YearOfProduction="2011"},
                                new CarModel{Name="Fiesta", YearOfProduction="2012"},
                                new CarModel{Name="Fiesta", YearOfProduction="2013"},
                                new CarModel{Name="Fiesta", YearOfProduction="2014"},
                                new CarModel{Name="Fiesta", YearOfProduction="2015"},
                                new CarModel{Name="Fiesta", YearOfProduction="2016"},
                                new CarModel{Name="Mondeo", YearOfProduction="2010"},
                                new CarModel{Name="Mondeo", YearOfProduction="2011"},
                                new CarModel{Name="Mondeo", YearOfProduction="2012"},
                                new CarModel{Name="Mondeo", YearOfProduction="2013"},
                                new CarModel{Name="Mondeo", YearOfProduction="2014"},
                                new CarModel{Name="Mondeo", YearOfProduction="2015"},
                                new CarModel{Name="Mondeo", YearOfProduction="2016"},
                                new CarModel{Name="Focus", YearOfProduction="2010"},
                                new CarModel{Name="Focus", YearOfProduction="2011"},
                                new CarModel{Name="Focus", YearOfProduction="2012"},
                                new CarModel{Name="Focus", YearOfProduction="2013"},
                                new CarModel{Name="Focus", YearOfProduction="2014"},
                                new CarModel{Name="Focus", YearOfProduction="2015"},
                        
                            }
                        }
                        
                        );
                list.Add(new Car
                        {
                            CarBrand = "Volkswagen",
                            carModel = new List<CarModel>{ 
                                new CarModel{Name="Polo", YearOfProduction="2010"},
                                new CarModel{Name="Polo", YearOfProduction="2011"},
                                new CarModel{Name="Polo", YearOfProduction="2012"},
                                new CarModel{Name="Polo", YearOfProduction="2013"},
                                new CarModel{Name="Polo", YearOfProduction="2014"},
                                new CarModel{Name="Polo", YearOfProduction="2015"},
                                new CarModel{Name="Golf", YearOfProduction="2010"},
                                new CarModel{Name="Golf", YearOfProduction="2011"},
                                new CarModel{Name="Golf", YearOfProduction="2012"},
                                new CarModel{Name="Golf", YearOfProduction="2013"},
                                new CarModel{Name="Golf", YearOfProduction="2014"},
                                new CarModel{Name="Golf", YearOfProduction="2015"},
                                new CarModel{Name="Passat", YearOfProduction="2010"},
                                new CarModel{Name="Passat", YearOfProduction="2011"},
                                new CarModel{Name="Passat", YearOfProduction="2012"},
                                new CarModel{Name="Passat", YearOfProduction="2013"},
                                new CarModel{Name="Passat", YearOfProduction="2014"},
                                new CarModel{Name="Passat", YearOfProduction="2015"},
                        
                            }
                        });
    
                var newCars = list.Where(s => s.carModel.Exists(m => m.YearOfProduction == "2016"));
    
                foreach (var brand in newCars)
                {
                    foreach (var model in brand.carModel)
                    {
                        Console.WriteLine("Brand:{0}, Model:{1}, YearOfPrd:{2}", brand.CarBrand, model.Name, model.YearOfProduction);
    
                    }
                }
                Console.ReadLine();
            }
        }
    }
