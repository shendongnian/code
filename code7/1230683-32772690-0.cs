    public class ClassA
    {
        protected Rect storedRect;
        public ClassA() { }
        public virtual void UpdateEverFrame();
        protected bool IsRectChanged(Rect rect)
        {
            bool isChanged = !rect.Equals(StoredRect);
            if(isChanged)
            {
                storedRect = rect;
            }
            return isChanged;
        }
    }
    public class ClassC : ClassA
    {
        public override void UpdateEverFrame()
        {
            if(IsRectChanged(new Rect(0, 0, 20, 20)))
            {
                 Debug.Log("Changes were made class C");
            }
        }
    }
    public class ClassD : ClassA
    {
        public override void UpdateEverFrame()
        {
            if(IsRectChanged(new Rect(100, 100, 10, 10)))
            {
                 Debug.Log("Changes were made class D");
            }
        }
    }
