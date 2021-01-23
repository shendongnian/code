    class ChildA : MyInterface<ChildB>
    {
        public ChildA()
        {
            this.ValidateGenericType();
        }
        public MyObj<ChildB> GetObj()
        {
            return new MyObj<ChildB>();
        }
        protected void ValidateGenericType()
        {
            //throws an Exception because ChildB is different of ChilA
            if (this.GetType().Name != this.GetType().GetInterfaces()[0].GetGenericArguments()[0].Name)
            {
                throw new Exception("The generic type must be of type ChildA.");
            }
        }
    }
