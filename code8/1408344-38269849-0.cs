    namespace test
    {
        interface A
        {
            bool IsFileValue();
            bool IsValidRow();
        }
        abstract class B : A
        {
            public bool IsFileValue()
            {
                return IsValidRow();
            }
            public abstract bool IsValidRow();
        }
        class C : B
        {
            public override bool IsValidRow()
            {
                return true;
            }
        }
    }
