    class Car
        {
            public string Model { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }
            //Rest of properties here
            public override string ToString()
            {
                string output = String.Format("Model :{0} \n Name :{1} \n Brand :{2}", this.Model, this.Name, this.Brand);
                return output;
            }
        }
