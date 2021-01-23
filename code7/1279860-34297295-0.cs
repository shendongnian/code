    namespace Mixins
    {
        using System;
        using Castle.DynamicProxy;
        using Xunit;
    
        public interface IA
        {
            void Do();
        }
    
        public interface IB
        {
            void Something();
        }
    
        public class A : IA
        {
            public void Do()
            {
                throw new NotImplementedException("A");
            }
        }
    
        public class B : IB
        {
            public void Something()
            {
                throw new NotImplementedException("B");
            }
        }
    
        public class Blender
        {
            [Fact]
            public void Mix()
            {
                var options = new ProxyGenerationOptions();
                // the instances for A and B would be the user provided and yours
                options.AddMixinInstance(new A());
                options.AddMixinInstance(new B());
                var proxy = new ProxyGenerator().CreateClassProxy<object>(options);
    
                Assert.IsAssignableFrom<IA>(proxy);
                Assert.IsAssignableFrom<IB>(proxy);
    
                try
                {
                    ((IA)proxy).Do();
                }
                catch (NotImplementedException ex)
                {
                    if (ex.Message != "A")
                    {
                        throw;
                    }
                }
    
                try
                {
                    ((IB)proxy).Something();
                }
                catch (NotImplementedException ex)
                {
                    if (ex.Message != "B")
                    {
                        throw;
                    }
                }
                
            }
        }
    }
