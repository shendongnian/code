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
                        IProvideValueTarget service = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
    
                        Binding binding = null;
                        
                        if (this.Path is string)
                        {
                            binding = new Binding { Mode = BindingMode.OneWay };
                        }
                        else if (this.Path is Binding)
                        {
                            binding = Path as Binding;
                        }
    else  if (this.Path is ImageSource) return this.Path;
                    else if (this.Path is System.Windows.Expression)
                    {
                        ResourceReferenceExpressionConverter cnv = new ResourceReferenceExpressionConverter();
                        DynamicResourceExtension mex = null;
                        try
                        {
                            mex = (MarkupExtension)cnv.ConvertTo(this.Path, typeof(MarkupExtension))
                                as DynamicResourceExtension;
                        }
                        catch (Exception) { }
    
                        if (mex != null)
                        {
                            FrameworkElement targetObject = service.TargetObject as FrameworkElement;
                            if (targetObject == null)
                            {
                                return Utils.GetEmpty(); 
                            }
                            return targetObject.TryFindResource(mex.ResourceKey as string);
                        }
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
