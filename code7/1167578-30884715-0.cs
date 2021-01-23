    public class MyTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);
    
            List<Member> members = value as List<Member>;
            if (members == null)
                return "-";
    
            return string.Join(", ", members.Select(m => m.Name));
        }
    
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            List<PropertyDescriptor> list = new List<PropertyDescriptor>();
            List<Member> members = value as List<Member>;
            if (members != null)
            {
                foreach (Member member in members)
                {
                    if (member.Name != null)
                    {
                        list.Add(new MemberDescriptor(member, list.Count));
                    }
                }
            }
            return new PropertyDescriptorCollection(list.ToArray());
        }
    
        private class MemberDescriptor : SimplePropertyDescriptor
        {
            public MemberDescriptor(Member member, int index)
                : base(member.GetType(), index.ToString(), typeof(string))
            {
                Member = member;
            }
    
            public Member Member { get; private set; }
    
            public override object GetValue(object component)
            {
                return Member.Name;
            }
    
            public override void SetValue(object component, object value)
            {
                Member.Name = (string)value;
            }
        }
    }
