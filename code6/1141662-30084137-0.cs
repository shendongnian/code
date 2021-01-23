        abstract class FamilyDecorator
        {
          protected Domain.Parent _member;
          public abstract void DoSomething();
          internal FamilyDecorator(Domain.Parent member)
          {
            _member = member;
          }
          public static FamilyDecorator GetDecorator(Domain.Parent item)
          {
            if(item.GetType() == typeof(Domain.Parent))
            {
              return new ParentDecorator(item);
            }
            else if (item.GetType() == typeof(Domain.Son))
            {
              return new SonDecorator(item);
            }
            else if (item.GetType() == typeof(Domain.Daughter))
            {
              return new DaughterDecorator(item);
            }
            return null;
          }
        }
        class ParentDecorator : FamilyDecorator
        {
          internal ParentDecorator(Domain.Parent parent)
            : base(parent)
          {
          }
          public override void DoSomething()
          {
            Console.WriteLine("A parent");
          }
        }
        class SonDecorator : FamilyDecorator
        {
          internal SonDecorator(Domain.Parent son)
            : base(son)
          {
            this._member = son;
          }
          public override void DoSomething()
          {
            Console.WriteLine("A son");
          }
        }
        class DaughterDecorator : FamilyDecorator
        {
          internal DaughterDecorator(Domain.Parent daughter)
            : base(daughter)
          {
          }
          public override void DoSomething()
          {
            Console.WriteLine("A daughter");
          }
        }
