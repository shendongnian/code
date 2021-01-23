        //gets the attributes from the enum
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }
        //this will pull the DisplayGroup from the Display attribute
        public static string DisplayGroup(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.GroupName;
        }
        //enum decoration looks like
        public enum MyEnum
        {
            [Display(GroupName = "MyGroupName")]
            AnEnum
        }
        //pull the group name like
        var groupName = MyEnum.AnEnum.DisplayGroup();
        //Assert.IsTrue(groupName.Equals("MyGroupName");
