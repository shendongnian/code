    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Data;
    using System.Linq;
    using System.Collections.ObjectMode;
    static void Main(string[] args)
    {
      using (var context = new TesterEntities())
      {
        var peopleWithOrderOfOne = context.tePersons.Where(x => x.OrderId == 1);
        // Go down to get the orders for Brett, Ryan, and Mark.  I am realizing an object that is a foreign key merely by selecting the complex object.
        // In this case x.teOrder is a POCO class mapped to another POCO class
        var observable = new ObservableCollection<teOrder>(peopleWithOrderOfOne.ToList().Select(x => x.teOrder).ToList());
        // display it
        observable.ToList().ForEach(x => Console.WriteLine($"{x.Description}"));
        //If you want to fully realize new objects you need to make them concrete by doing a select followed by a toList to materialize them, else they are not realized yet.
        // THis WILL NOT WORK:
        //var madeupPeopleAndOrders = context.tePersons
        //  .Select(x =>
        //    new tePerson
        //    {
        //      FirstName = x.FirstName,
        //      LastName = x.LastName,
        //      teOrder = new teOrder
        //      {
        //        OrderId = x.OrderId.Value,
        //        Description = x.teOrder.Description
        //      }
        //    });
        // THis WILL WORK:
        var madeupPeopleAndOrders = context.tePersons
          .ToList()
          .Select(x =>
            new tePerson
            {
              FirstName = x.FirstName,
              LastName = x.LastName,
              teOrder = new teOrder
              {
                OrderId = x.OrderId.Value,
                Description = x.teOrder.Description
              }
            });
        madeupPeopleAndOrders.ToList().ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} {x.teOrder.Description}"));
      }
      Console.ReadLine();
    }
