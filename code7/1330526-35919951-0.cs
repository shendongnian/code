    public class AttachedPropertySample
    {
        private string _autoProperty;
    ​
        //this is equivalent to AttachedBindingMember.CreateAutoProperty<AttachedPropertySample, string>("AutoProperty", OnAutoPropetyChanged);
        //In auto member you cannot control logic of set and get method you can also listen when this property is changed
        public string AutoProperty
        {
            get { return _autoProperty; }
            set
            {
                _autoProperty = value;
                OnAutoPropetyChanged();
            }
        }
    
        //this is equivalent to ​AttachedBindingMember.CreateMember<AttachedPropertySample, string>("CustomMember", (info, sample) => "My custom value", (info, sample, arg3) => CustomMemberSetter(arg3))
        //In custom member you can control logic of set, get and observe methods
        public string CustomMember
        {
            get { return "My custom value"; }
            set { CustomMemberSetter(value); }
        }
    
        private void CustomMemberSetter(string value)
        {
    
        }
    ​
        private void OnAutoPropetyChanged()
        {
        }
    }
