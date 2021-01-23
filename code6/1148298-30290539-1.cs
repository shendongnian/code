    namespace FactoryDesignPattern
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                Factory[] objFactories = new Factory[2];
                objFactories[0] = new ConcreteFactoryForProduct1();
                objFactories[1] = new ConcreteFactoryForProduct2();
                foreach (Factory objFactories in objFactories)
                {
                    product objProduct = objFactory.GetProduct();
                    objProduct.GetDetails();
                }
            }
        }
        public abstract class Factory
        {
            public abstract Product GetProduct();
        }
        public class ConcreteFactoryForProduct1: Factory
        {
            public override Product GetProduct()
            {
                return new Product1();
            }
        }
        public class ConcreteFactoryForProduct2: Factory
        {
            public override Product GetProduct()
            {
                return new Product2();
            }
        }
        public interface Product
        {
            void GetDetails();
        }
        public class Product1 : Product
        {
            public void GetDetails(){
                Trace.WriteLine("Product 1 details are: ");
            }
        }
        public class Product2 : Product
        {
            public void GetDetails(){
                Trace.WriteLine("Product 2 details are: ");
            }
        }
    }
