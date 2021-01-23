    <TextBox Grid.Row="3" Grid.Column="1">
        <TextBox.Text>
        <Binding Path="Model.TitleValuesDelimitedString" Delay="500"              
             ConverterParameter="{x:Static local:UICodeLists.TitleCodeList}"
             UpdateSourceTrigger="PropertyChanged">
        <Binding.ValidationRules>
         <vrules:TitlesSpaceSeparated />
      </Binding.ValidationRules>
      <Binding.Converter>
          <local:TitleValuesDelimitedStringToDisplayStringConverter />
      </Binding.Converter>
    </Binding>
