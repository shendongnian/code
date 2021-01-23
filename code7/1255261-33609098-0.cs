    [ImplementPropertyChanged]
    public class MyViewModel : IDataErrorInfo
    {
        public Gender Gender { get; set; }
    
        public MyViewModel()
        {
            Gender = Gender.Unknown;
        }
    	
    	public string this[string name]
    	{
    		get
    		{
    			if (name == "Gender" && Gender == Gender.Unknown)
    			{
    				return "Gender need to be known";
    			}
    			return null;
    		}
    	}
    
    	public string Error
    	{
    		get
    		{
    			return null;
    		}
    	}
    }
    
    <StackPanel Orientation="Horizontal">
        <RadioButton Content="Male" IsChecked="{Binding Gender, ConverterParameter={x:Static data:Gender.Male}, Converter={StaticResource EnumToBooleanConverter}, NotifyOnSourceUpdated=True, ValidatesOnDataErrors=True}"/>
        <RadioButton Content="Female" IsChecked="{Binding Gender, ConverterParameter={x:Static data:Gender.Female}, Converter={StaticResource EnumToBooleanConverter}, NotifyOnSourceUpdated=True, ValidatesOnDataErrors=True}"/>
    </StackPanel>
