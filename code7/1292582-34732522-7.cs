        public override bool ShouldMap(Member member)
		{
			return base.ShouldMap(member) && member.CanWrite &&
			       !member.MemberInfo.IsDefined(typeof(NotMappedAttribute), false);
		}
    In your case, if the enum is in the same namespace you should do:
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "Domain"
                && !type.IsEnum;
        }
    (which is a bit counter-intuitive)
