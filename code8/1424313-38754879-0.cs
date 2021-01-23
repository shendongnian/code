    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    
    namespace Utilities_Tests
    {
    
        public class ParentClass
        {
            public List<ParentClass> Children { get; set; }
    
            public string Name { get; set; }
    
            public virtual char Sex { get; private set; }
    
            public virtual bool IAmTheUniqueGrandPapa { get { return true; } }
    
            public ParentClass BringToLife(int atype)
            {
                ParentClass newItem = this;
    
                switch (atype)
                {
                    case 1: newItem = new MaleChild() { Name = $"I am a child of {Name}" }; break;
                    case 2: newItem = new FemaleChild() { Name = $"I am a child of {Name}" }; break;
                    case 3: newItem = new OtherChild() { Name = $"I am a child of {Name}" }; break;
                }
    
                Children.Add(newItem);
                return newItem;
            }
    
            public ParentClass(char sex = 'F')
            {
                Children = new List<ParentClass>();
                Sex = sex;
            }
        }
    
    
        public class MaleChild : ParentClass
        {
            public override bool IAmTheUniqueGrandPapa { get { return false; } }
            public override char Sex { get { return 'M'; } }
        }
    
        public class FemaleChild : ParentClass
        {
            public override bool IAmTheUniqueGrandPapa { get { return false; } }
            public override char Sex { get { return 'F'; } }
        }
    
        public class OtherChild : ParentClass
        {
            public override bool IAmTheUniqueGrandPapa { get { return false; } }
            public override char Sex { get { return '?'; } }
        }
    
    
        public class NewDictionary<K, V> : Dictionary<K, V> where V : ParentClass
        {
            public void AddOne(K key, V fromWhom, int atype)
            {
                this[key] = (V)fromWhom.BringToLife(atype);
            }
        }
    
    
        [TestClass]
        public class AStrangeRequest
        {
            [TestMethod]
            public void AStrangeTest()
            {
                var dict = new NewDictionary<uint, ParentClass>();
    
                var aParent = new ParentClass();
    
                dict.AddOne(00, aParent, 0); // F parent
                dict.AddOne(11, aParent, 1); // M
                dict.AddOne(22, aParent, 2); // F
                dict.AddOne(33, aParent, 3); // ?            
    
                Assert.IsTrue(dict[0].IAmTheUniqueGrandPapa == true && dict[0].Sex == 'F');
                Assert.IsTrue(dict[0].Children.Count > 0);
    
                Assert.IsTrue(dict[11].IAmTheUniqueGrandPapa == false && dict[11].Sex == 'M');
                Assert.IsTrue(dict[11].Children.Count == 0);
    
                Assert.IsTrue(dict[22].IAmTheUniqueGrandPapa == false && dict[22].Sex == 'F');
                Assert.IsTrue(dict[22].Children.Count == 0);
    
                Assert.IsTrue(dict[33].IAmTheUniqueGrandPapa == false && dict[33].Sex == '?');
                Assert.IsTrue(dict[33].Children.Count == 0);
            }
        }
    }
