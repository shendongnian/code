        namespace FamilyNamespace
        {
          interface IFamily
          {
            void DoSomething();
          }
          class ParentDecorator : Domain.Parent, IFamily
          {
            private Domain.Parent _member;
            public ParentDecorator(Domain.Parent parent)
            {
              this._member = parent;
            }
            public void DoSomething()
            {
              Console.WriteLine("A parent");
            }
          }
          class SonDecorator : Domain.Son, IFamily
          {
            private Domain.Parent _member;
            public SonDecorator(Domain.Parent son)
            {
              this._member = son;
            }
            public void DoSomething()
            {
              Console.WriteLine("A son");
            }
          }
          class DaughterDecorator : Domain.Daughter, IFamily
          {
            private Domain.Parent _member;
            public DaughterDecorator(Domain.Parent daughter)
            {
              this._member = daughter;
            }
            public void DoSomething()
            {
              Console.WriteLine("A daughter");
            }
          }
        }
