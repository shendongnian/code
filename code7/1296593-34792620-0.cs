        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <Config>
      <PopulationSize>100</PopulationSize>
      <SpecieCount>20</SpecieCount>
      <Activation>
        <Scheme>FixedIters</Scheme>
        <Iters>1</Iters>
      </Activation>
      <ComplexityRegulationStrategy>Absolute</ComplexityRegulationStrategy>
      <ComplexityThreshold>500</ComplexityThreshold>
      <Description>
        Helikopter game
      </Description>
      <Timesteps>50000</Timesteps> //Length of the world (x-axis)
      <Worldheight>200</Worldheight> //Height of the world (y-axis)
      <SensorInputs>10</SensorInputs> //Length of one side of the rectangle that is used as the input. So 15 here means 15*15 = 225 inputs
      <Speler>computer</Speler>
    </Config>";
    
            XDocument doc = XDocument.Parse(xml);
    
            List<XElement> elements = doc.Descendants("Config").ToList();
    
            foreach (XElement elem in elements)
            {
                elem.Element("Speler").Value = "mens";
    
                Console.WriteLine(elem.Element("Speler").Value);
            }
    
            Console.ReadKey();
        }
