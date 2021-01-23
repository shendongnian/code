     public class MyDynamic: DynamicObject
    {
        static int Count = 0;
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = Count++;
            if (binder.Name == "Test")
            {
                return Count % 2 == 0;
            }
            return false;
        }
    }
