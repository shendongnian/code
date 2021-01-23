    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPart1();
            builder.BuildPart2();
            builder.BuildPart3();
        }
    }
    public abstract class Builder
    {
        public abstract void BuildPart1();
        public abstract void BuildPart2();
        public abstract void BuildPart3();
        public abstract Product GetProduct();
    }
    public class ConcreteBuilder : Builder
    {
        private Product _product = new Product();
        public override void BuildPart1()
        {
            _product.Part1 = "Part 1";
        }
        public override void BuildPart2()
        {
            _product.Part2 = "Part 2";
        }
        public override void BuildPart3()
        {
            _product.Part3 = "Part 3";
        }
        public override Product GetProduct()
        {
            return _product;
        }
    }
    public class Product
    {
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
    }
