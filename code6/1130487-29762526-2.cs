        <Window.Resources>
        <local:TextBlockConverter x:Key="Conv"/>
    </Window.Resources>
    
     <TextBlock>
            <TextBlock.Text>
                <MultiBinding Converter="{StaticResource Conv}" UpdateSourceTrigger="PropertyChanged">
                    <Binding RelativeSource="{RelativeSource Self}" Mode="OneTime"/>
                    <Binding Path="senselist" />
                </MultiBinding>
            </TextBlock.Text>
        </TextBlock>
   
    class TextBlockConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TextBlock txt =  values[0] as TextBlock; 
            string str = (string)values[1];
            string[] strList = str.Split('|');
            Run run1 = new Run(strList[0]);
            run1.FontWeight = FontWeights.Bold;
            Run run2 = new Run(strList[1]);
            Hyperlink hyp = new Hyperlink(run2);
            txt.Inlines.Add(run1);
            txt.Inlines.Add(hyp);
            return txt;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
     senselist = "sense_list" + "|" + "gramGroup";
