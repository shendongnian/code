    public Class AClass
    {
        private SomeClass A;
        private SomeClass B;
        private SomeClass C;
        private SomeClass D;
        private enum SomeEnum {A, B, C, D};
        public void UpdateInstance (SomeEnum theEnum, SomeClass newClass)
        {
            switch(theEnum)
            {
              case SomeEnum.A:
                A = newClass;
                break;
              case SomeEnum.B:
                B = newClass;
                break;
              case SomeEnum.C:
                C = newClass;
                break;
              case SomeEnum.D:
                D = newClass;
                break;
            }
        }
    }
