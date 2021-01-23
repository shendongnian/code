    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyLinq;
    var test = Enumerable.Range(0, 100)
    	.Select(n => new { Foo = 1 + (n / 20), Bar = 1 + n })
    	.OrderByDescending(e => e.Foo)
    	.Where(e => (e.Bar % 2) == 0)
    	.ThenByDescending(e => e.Bar) // Note this compiles:)
    	.ToList();
