        public class DepartmentBindModelConverter : TypeConverter
        {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                return destinationType == typeof(DepartmentViewModel); // Removed || destinationType == typeof(string), to allow newtonsoft json convert model with typeconverter attribute
            }
    
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                if (value == null)
                    return null;
    
                if (destinationType == typeof(DepartmentViewModel) && value is DepartmentBindModel)
                {
                    var department = (DepartmentBindModel) value;
    
                    return new DepartmentViewModel
                    {
                        Id = department.Id,
                        Name = department.Name,
                        GroupName = department.GroupName,
                        ReturnUrl = department.ReturnUrl
                    };
    
                }
    
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
