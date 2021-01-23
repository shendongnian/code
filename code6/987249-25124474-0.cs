        public class CommunicationTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }
    
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
            }
    
            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string)
                {
                    switch ((string)value)
                    {
                        case "OUTGOING_EMAIL":
                            return CommunicationType.OutgoingEmail;
                        default:
                            return CommunicationType.OutgoingCall;
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }
    
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    if (value is CommunicationType)
                    {
                        switch ((CommunicationType)value)
                        {
                            case CommunicationType.OutgoingEmail:
                                return "OUTGOING_EMAIL";
                            default:
                                return "OUTGOING_CALL";
                        }
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
