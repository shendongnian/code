    public class ImgSourceExtension : MarkupExtension
        {
            [ConstructorArgument("Path")] // IMPORTANT!!
            public object Path { get; set; }
    
            public ImgSourceExtension():base() { }
    
            public ImgSourceExtension(object Path)
                : base()
            {
                this.Path = Path;
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                object returnValue = null;
                try
                {
                    Binding binding = null;
                    
                    if (this.Path is string)
                    {
                        binding = new Binding { Mode = BindingMode.OneWay };
                    }
                    else if (this.Path is Binding)
                    {
                        binding = Path as Binding;
                    }
                    else return Utils.GetEmpty();
    
                    
                    binding.Converter = new Converter_StringToImageSource();
                    binding.ConverterParameter = Path is Binding ? null : Path as string;
    
                    returnValue = binding.ProvideValue(serviceProvider);
                }
                catch (Exception) { returnValue = Utils.GetEmpty(); }
                return returnValue;
            }
        }
