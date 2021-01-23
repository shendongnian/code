    using System.Linq;
    var result = collection.select(c=> new RowColumns {
       Col1 = c.Col1,
       Col2 = c.Col2
    });
