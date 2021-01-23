    public enum Sides
    {
        Left,
    }
    public class Car
    {
    }
    public class CarBuilderWithSyntax
    {
        protected CarBuilderWithSyntax ParentBuilder { get; private set; }
        public static CarBuilderWithSyntax Create()
        {
            return new CarBuilderWithSyntax(null);
        }
        protected CarBuilderWithSyntax(CarBuilderWithSyntax parent)
        {
            ParentBuilder = parent;
        }
        protected CarBuilderWithSyntax GetParentBuilder()
        {
            CarBuilderWithSyntax parentBuilder = this;
            while (parentBuilder.ParentBuilder != null)
            {
                parentBuilder = parentBuilder.ParentBuilder;
            }
            return parentBuilder;
        }
        public DoorBuilder WithDoor()
        {
            return new DoorBuilder(GetParentBuilder());
        }
        public CarBuilderWithSyntax WithEngine(int cmq)
        {
            if (ParentBuilder != null)
            {
                return GetParentBuilder().WithEngine(cmq);
            }
            // Save somewhere this information
            return this;
        }
        public Car Build()
        {
            return null;
        }
        public class DoorBuilder : CarBuilderWithSyntax
        {
            public DoorBuilder(CarBuilderWithSyntax builder)
                : base(builder)
            {
            }
            protected new DoorBuilder GetParentBuilder()
            {
                DoorBuilder parentBuilder = this;
                while ((parentBuilder.ParentBuilder as DoorBuilder) != null)
                {
                    parentBuilder = parentBuilder.ParentBuilder as DoorBuilder;
                }
                return parentBuilder;
            }
            public DoorBuilder HavingSide(Sides side)
            {
                // Save side this information somewhere
                return GetParentBuilder();
            }
            public WindowBuilder WithWindow()
            {
                return new WindowBuilder(this);
            }
            public class WindowBuilder : DoorBuilder
            {
                public WindowBuilder(DoorBuilder builder)
                    : base(builder)
                {
                }
                public WindowBuilder HavingWidth(int width)
                {
                    // Terminal elements don't need to do the GetParentBuilder()
                    return this;
                }
                public WindowBuilder HavingHeight(int width)
                {
                    // Terminal elements don't need to do the GetParentBuilder()
                    return this;
                }
            }
        }
    }
