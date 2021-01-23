    var serializer = new XmlSerializer(typeof(SpeedLineMenuXml));
    SpeedLineMenuXml root;
    using (var reader = new StringReader(@"<SpeedLineMenu>
    <Children>
      <ValueMealTreeRoot>
        <Name Type=""String"">Value Meals</Name>
        <SequenceID Type=""Integer"">0</SequenceID>
        <IsActive Type=""Boolean"">true</IsActive>
        <Children>
          <Group>
            <Name Type=""String"">Lunch Specials</Name>
            <SequenceID Type=""Integer"">3872</SequenceID>
            <IsActive Type=""Boolean"">true</IsActive>
            <Caption Type=""String"">Lunch Specials</Caption>
            <Children>
              <ValueMeal></ValueMeal>
            </Children>
           </Group>
        </Children>
       </ValueMealTreeRoot>
    </Children>
    </SpeedLineMenu>"))
    {
      root = (SpeedLineMenuXml)serializer.Deserialize(reader);
    }
