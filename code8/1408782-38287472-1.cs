    using System;
    using System.Collections;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Reflection;
    namespace PropertyNameFromExpression
    {
        [TestClass]
        public class PropertyNameTests
        {
            [TestMethod]
            public void TestCanGetEasyExpression()
            {
                string propertyName = PropertyName<Source>(e => e.Easy);
                Assert.AreEqual("Easy", propertyName);
            }
            [TestMethod]
            public void TestCanGetNotSoEasyExpression()
            {
                string propertyName = PropertyName<Source>(e => e.Not.So.Easy);
                Assert.AreEqual("Not.So.Easy", propertyName);
            }
            [TestMethod]
            public void TestCanGetArrayExpressionWithConstantIndex()
            {
                string propertyName = PropertyName<Difficult>(e => e.ImLost[3]);
                Assert.AreEqual("ImLost["+3+"]", propertyName);
            }
            [TestMethod]
            public void TestCanGetArrayExpressionWithVariableIndex()
            {
                int i = 3;
                string propertyName = PropertyName<Difficult>(e => e.ImLost[i]);
                Assert.AreEqual("ImLost[" + i + "]", propertyName);
            }
            public string PropertyName<TSource>(Expression<Func<TSource, int>> expression)
            {
                return PropertyName(expression.Body);
            }
            private string PropertyName(Expression expression)
            {
                if (expression is BinaryExpression)
                {
                    return PropertyName(expression as BinaryExpression);
                }
                if (expression is ConstantExpression)
                {
                    return (expression as ConstantExpression).Value.ToString();
                }
                MemberExpression memberExpression = expression as MemberExpression;
                if (memberExpression.Expression is MemberExpression)
                {
                    return PropertyName(memberExpression.Expression) + "." + memberExpression.Member.Name;
                }
                if (memberExpression == null)
                {
                    throw new ArgumentException("Unknown Expression type:"+expression.GetType().Name);
                }
                if (memberExpression.Member.MemberType == MemberTypes.Field)
                {
                    var f = Expression.Lambda(memberExpression).Compile();
                    object value = f.DynamicInvoke();
                    return value.ToString();
                }
                return memberExpression.Member.Name;
            }
            private string PropertyName(BinaryExpression binaryExpression)
            {
                if (typeof(IEnumerable).IsAssignableFrom(binaryExpression.Left.Type))
                {
                    return PropertyName(binaryExpression.Left) + "[" + PropertyName(binaryExpression.Right) + "]";
                }
                return PropertyName(binaryExpression.Left) + "." + PropertyName(binaryExpression.Right);
            }
        }
        public class Source
        {
            public int Easy { get; set; }
            public Level2 Not { get; set; }
        }
        public class Level2
        {
            public Level3 So { get; set; }
        }
        public class Level3
        {
            public int Easy { get; set; }
        }
        public class Difficult
        {
            public int[] ImLost { get;set; }
        }
    }
